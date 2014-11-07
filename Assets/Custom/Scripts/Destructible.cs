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
		if (offender.healthPoints - velocity < 0) {
			offender.healthPoints = 0;
		} else{
			offender.healthPoints -= velocity;
		}

		if(this.healthPoints == 0){
            Explosive explosive = this.gameObject.AddComponent<Explosive>();
            explosive.explosionPrefab = explosionPrefab;
            return;
        }
	}

	public void healing(int HP)
	{
		if (this.healthPoints + HP < this.maxHealthPoints) {
			this.healthPoints += HP;
		} else {
			this.healthPoints = this.maxHealthPoints;
		}
    }
}
