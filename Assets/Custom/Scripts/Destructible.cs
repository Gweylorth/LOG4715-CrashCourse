using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

    public Transform explosionPrefab;
	public int healthPoints = 50;
	public int maxHealthPoints = 50;

	void OnCollisionEnter(Collision collision) {
        Destructible offender = collision.gameObject.GetComponentInParent<Destructible>();
		if (!offender) {
			return;
		}

        int velocity = Mathf.FloorToInt(collision.relativeVelocity.magnitude / 10);
		
		if (this.healthPoints - velocity < 0) {
			this.healthPoints = 0;
		} else{
			this.healthPoints -= velocity;
		}

		if(this.healthPoints == 0) {
            Explosive explosive = this.gameObject.AddComponent<Explosive>();
			if(explosive) {
				explosive.explosionPrefab = explosionPrefab;
			}
        }
		if (offender.healthPoints - velocity <= 0) {
			Style car = this.gameObject.GetComponentInChildren<Style>();
			if(car) {
				car.AddExplosionPoints();
			}
		}
	}

	public void Healing(int HP)
	{
		if (this.healthPoints + HP < this.maxHealthPoints) {
			this.healthPoints += HP;
		} else {
			this.healthPoints = this.maxHealthPoints;
		}
    }
}
