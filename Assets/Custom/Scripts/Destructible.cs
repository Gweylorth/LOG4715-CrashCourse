using UnityEngine;
using System.Collections;

// Manage HP for destructibles objects like cars or obstacles for example
public class Destructible : MonoBehaviour {

	// Explosion
    public Transform explosionPrefab;
	// Number of HP
	public int healthPoints = 50;
	// Maximum of HP
	public int maxHealthPoints = 50;

	// Called when the collider enters the trigger
	void OnCollisionEnter(Collision collision) {
		// Find the offender
        Destructible offender = collision.gameObject.GetComponentInParent<Destructible>();
		if (!offender) {
			return;
		}

		// calculate velocity
        int velocity = Mathf.FloorToInt(collision.relativeVelocity.magnitude / 10);
		
		// Damage the component by velocity
		if (this.healthPoints - velocity < 0) {
			this.healthPoints = 0;
		} else{
			this.healthPoints -= velocity;
		}

		// If dead, explose
		if(this.healthPoints == 0) {
            Explosive explosive = this.gameObject.AddComponent<Explosive>();
			if(explosive) {
				explosive.explosionPrefab = explosionPrefab;
			}
        }
		// If a car caused an explosion, add style points
		if (offender.healthPoints - velocity <= 0) {
			Style car = this.gameObject.GetComponentInChildren<Style>();
			if(car) {
				car.AddExplosionPoints();
			}
		}
	}

	// Heal the component
	public void Healing(int HP)
	{
		if (this.healthPoints + HP < this.maxHealthPoints) {
			this.healthPoints += HP;
		} else {
			this.healthPoints = this.maxHealthPoints;
		}
    }
}
