using UnityEngine;

[RequireComponent(typeof(CarController))]
public class CarUserControlMP : MonoBehaviour
{
	private CarController car;  // the car controller we want to use
	private float baseSpeed;
	private float baseTorque;
	
	public float speedFactor = 2;

	[SerializeField]
	private string vertical = "Vertical";

	[SerializeField]
	private string horizontal = "Horizontal";
	
	void Awake ()
	{
		// get the car controller
		car = GetComponent<CarController>();
		this.baseSpeed = this.car.MaxSpeed;
		this.baseTorque = this.car.MaxTorque;
	}

	void FixedUpdate()
	{
		// pass the input to the car!
		#if CROSS_PLATFORM_INPUT
		float h = CrossPlatformInput.GetAxis(horizontal);
		float v = CrossPlatformInput.GetAxis(vertical);
		#else
		float h = Input.GetAxis(horizontal);
		float v = Input.GetAxis(vertical);
		#endif
		car.Move(h,v);

		if (CrossPlatformInput.GetButton ("Jump")) {
			car.MaxSpeed = this.baseSpeed * this.speedFactor * 2;
			car.MaxTorque = this.baseTorque * this.speedFactor;
		} else {
			car.MaxSpeed = this.baseSpeed;
			car.MaxTorque = this.baseTorque;
		}
	}
}
