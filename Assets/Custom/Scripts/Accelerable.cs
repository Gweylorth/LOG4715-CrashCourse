using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CarController))]
public class Accelerable : MonoBehaviour {

    private CarController carController;
    private float baseSpeed;
    private bool accelerating = false;

    public float accelTime = 2;

	// Use this for initialization
	void Start () {
        this.carController = this.GetComponent<CarController>();
        this.baseSpeed = this.carController.MaxSpeed;
	}

    public IEnumerator Accelerate(float speedFactor)
    {
        if (this.accelerating)
        {
            yield return new WaitForSeconds(0);
        }

        this.accelerating = true;
        this.carController.MaxSpeed = this.baseSpeed * speedFactor;
        this.carController.Boost(speedFactor);
        
        yield return new WaitForSeconds(this.accelTime);

        this.carController.MaxSpeed = this.baseSpeed;
        this.accelerating = false;
    }
}
