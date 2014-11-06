using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class Healing : MonoBehaviour
{
	
		public float spawnTime = 2;
		public int HP;
	
		void OnTriggerEnter (Collider other)
		{
				if (renderer.enabled) {
						Destructible heal = other.GetComponentInParent<Destructible> ();
						if (heal) {
								renderer.enabled = false;
								heal.healing (this.HP);
								StartCoroutine (Delay ());
						}
				}
		}
	
		IEnumerator Delay ()
		{
				yield return new WaitForSeconds (spawnTime);
				renderer.enabled = true;
		}
}
