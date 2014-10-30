using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CarController))]
public class Accelerable : MonoBehaviour {

    private CarController carController;
    private float baseSpeed;
    private float baseTorque;
    private bool accelerating = false;

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

    public IEnumerator Accelerate(float speedFactor)
    {
        if (this.accelerating)
        {
            yield return new WaitForSeconds(0);
        }

        this.accelerating = true;
        this.carController.MaxSpeed = this.baseSpeed * speedFactor * 2;
        this.carController.MaxTorque = this.baseTorque * speedFactor;
        
        yield return new WaitForSeconds(this.accelTime);

        this.carController.MaxSpeed = this.baseSpeed;
        this.carController.MaxTorque = this.baseTorque;
        this.accelerating = false;
    }
}
