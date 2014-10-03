using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CarController))]
public class Accelerable : MonoBehaviour {

    private CarController carController;
    private float baseSpeed;
    private float baseTorque;

    public float accelTime = 2;

	// Use this for initialization
	void Start () {
        this.carController = this.GetComponent<CarController>();
        this.baseSpeed = this.carController.MaxSpeed;
        this.baseTorque = this.carController.MaxTorque;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerable Accelerate(float speedFactor)
    {
        this.carController.MaxSpeed = this.baseSpeed * speedFactor;
        this.carController.MaxTorque = this.baseTorque * speedFactor;
        yield return new WaitForSeconds(this.accelTime);
        this.carController.MaxSpeed = this.baseSpeed;
        this.carController.MaxTorque = this.baseTorque;
    }
}
