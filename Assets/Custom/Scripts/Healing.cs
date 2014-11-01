using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class Healing : MonoBehaviour {
	
	public float spawnTime = 2;
	public int HP;
	
	void OnTriggerEnter(Collider other)
	{
		Healable heal = other.GetComponentInParent<Healable>();
		if (heal)
		{
			heal.healing(this.HP);
			StartCoroutine(Delay ());
		}
	}
	
	IEnumerator Delay() {
		gameObject.SetActive(false);
		yield return new WaitForSeconds(spawnTime);
		gameObject.SetActive(true);
	}
}
