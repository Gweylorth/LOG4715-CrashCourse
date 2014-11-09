using UnityEngine;
using System.Collections;

// Provides healing to nuts
public class Healing : MonoBehaviour {

	// Spawn time
	public float spawnTime = 2;
	// Number of HP recovered
	public int HP;
	
	// Called when the collider enters the trigger
	void OnTriggerEnter (Collider other)
	{
		// If nut is active
		if (renderer.enabled) {
			Destructible heal = other.GetComponentInParent<Destructible> ();
			if (heal) {
				renderer.enabled = false;
				// Heal car
				heal.Healing (this.HP);
				StartCoroutine (Delay ());
			}
		}
	}
	
	// Desactivate nut during a spawn time
	IEnumerator Delay ()
	{
		yield return new WaitForSeconds (spawnTime);
		renderer.enabled = true;
	}
}
