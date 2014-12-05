using UnityEngine;
using System.Collections;

public class BackAndForthMovement : MonoBehaviour {

    public Vector3 moveAxis;
    public float speed = 1f;
    public float distance = 1f;

    private Vector3 originalPosition;

	// Use this for initialization
	void Start () {
        this.originalPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(
                moveAxis.x * Mathf.PingPong(Time.time * this.speed, this.distance) + this.originalPosition.x,
                moveAxis.y * Mathf.PingPong(Time.time * this.speed, this.distance) + this.originalPosition.y,
                moveAxis.z * Mathf.PingPong(Time.time * this.speed, this.distance) + this.originalPosition.z
            );
	}
}
