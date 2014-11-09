using UnityEngine;
using System.Collections;

// Accelerate the car
public class Accelerable : MonoBehaviour {

	// The car
    private CarController carController;
	// The original speed
    private float baseSpeed;
	// If the car is already accelerating
    private bool accelerating = false;

    public float accelTime = 2;

	// Use this for initialization
	void Start () {
        this.carController = this.GetComponent<CarController>();
        this.baseSpeed = this.carController.MaxSpeed;
	}

	// Accelerate the car
    public IEnumerator Accelerate(float speedFactor)
    {
		// If already accelerating, return
        if (this.accelerating)
        {
            yield return new WaitForSeconds(0);
        }

		// Add a boost
        this.accelerating = true;
        this.carController.MaxSpeed = this.baseSpeed * speedFactor;
        this.carController.Boost(speedFactor);
        
        yield return new WaitForSeconds(this.accelTime);

		// Back to normal
        this.carController.MaxSpeed = this.baseSpeed;
        this.accelerating = false;
    }
}
