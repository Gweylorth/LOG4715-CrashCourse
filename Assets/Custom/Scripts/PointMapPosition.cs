using UnityEngine;
using System.Collections;

public class PointMapPosition : MonoBehaviour {
	
	// GameObject Car
	[SerializeField]
	private GameObject car;
    // Point color, should be same as car
    [SerializeField]
    private Color color;
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
        if (!this.car.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
		this.gameObject.transform.position = new Vector3(offsetX, height, offsetZ);
        this.gameObject.renderer.material.color = this.color;
	}

	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = new Vector3(car.transform.position.x, height, car.transform.position.z); 
	}
}
