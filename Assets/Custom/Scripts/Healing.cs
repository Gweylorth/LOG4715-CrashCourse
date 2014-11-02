﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class Healing : MonoBehaviour {
	
	public float spawnTime = 2;
	public int HP;
	
	void OnTriggerEnter(Collider other)
	{
		Destructible heal = other.GetComponentInParent<Destructible>();
		if (heal)
		{
			heal.healing(this.HP);
			gameObject.SetActive(false);
			StartCoroutine(Delay ());
		}
	}
	
	IEnumerator Delay() {
		yield return new WaitForSeconds(spawnTime);
		gameObject.SetActive(true);
	}
}
