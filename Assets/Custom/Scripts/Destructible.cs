using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

	public int healthPoints = 50;

	void OnCollisionEnter(Collision collision) {
        Destructible offender = collision.gameObject.GetComponentInParent<Destructible>();
		if (!offender) {
			return;
		}

        int velocity = Mathf.FloorToInt(collision.relativeVelocity.magnitude / 10);
        this.healthPoints -= velocity;
        offender.healthPoints -= velocity;

        if (this.healthPoints <= 0)
        {
            this.gameObject.AddComponent<Explosive>();
            return;
        }
	}


}
