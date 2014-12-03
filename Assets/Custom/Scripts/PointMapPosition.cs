﻿using UnityEngine;
using System.Collections;

public class PointMapPosition : MonoBehaviour {
	
	// GameObject Car
	[SerializeField]
	private GameObject car;
	// Height
	[SerializeField]
	public float height;

	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = new Vector3(car.transform.position.x, height, car.transform.position.z); 
	}
}
