using UnityEngine;
using System.Collections;

public class PointMapPosition : MonoBehaviour {
	
	// GameObject Car
	[SerializeField]
	private CarController car;
	// Height
	[SerializeField]
	private float height;
	// Offset X
	[SerializeField]
	private float offsetX;
	// Offset Z
	[SerializeField]
	private float offsetZ;

	void Start() {
		this.gameObject.transform.position = new Vector3(offsetX, height, offsetZ);
	}

	// Update is called once per frame
	void Update () {
		if(car.enabled){
			this.gameObject.transform.position = new Vector3(car.transform.position.x, height, car.transform.position.z); 
		}
	}
}
