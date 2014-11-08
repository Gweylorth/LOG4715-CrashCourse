﻿using UnityEngine;
using System.Collections;

public class Explosive : MonoBehaviour {

	public Transform explosionPrefab;
	bool exploded;
	public float detonationImpactVelocity = 10;
	public float sizeMultiplier = 1;
	public bool reset = true;
	public float resetTimeDelay = 10;

	void Start() {}  // here to make the enabled tickbox appear in the inspector! :)

	IEnumerator OnCollisionEnter(Collision col)
	{
		if (enabled)
		{
			if (col.contacts.Length > 0) // this has happened... :(
			{
				// compare relative velocity to collision normal - so we don't explode from a fast but gentle glancing collision
				float velocityAlongCollisionNormal = Vector3.Project(col.relativeVelocity,col.contacts[0].normal).magnitude;

				if (velocityAlongCollisionNormal > detonationImpactVelocity || exploded)
				{

					if (!exploded)
					{
						Instantiate(explosionPrefab, col.contacts[0].point, Quaternion.LookRotation( col.contacts[0].normal ));
						exploded = true;

                        CarController car = this.gameObject.GetComponent<CarController>();
                        if (car)
                        {
                            car.SendMessage("Immobilize");
                        }
                        else
                        {
                            this.gameObject.SetActive(false);
                        }


						if (reset)
						{
							ObjectResetter solid = this.gameObject.GetComponent<ObjectResetter>();
							if(solid) {
								solid.DelayedReset(resetTimeDelay);
							}
						}


					}
				}
			}
		}

		yield return null;
	}




	public void Reset()
	{
		exploded = false;
	}
}

