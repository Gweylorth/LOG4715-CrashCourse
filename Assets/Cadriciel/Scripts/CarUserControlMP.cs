using UnityEngine;

[RequireComponent(typeof(CarController))]
public class CarUserControlMP : MonoBehaviour
{
	private CarController car;  // the car controller we want to use
	private bool nitro;
	
	public float speedFactor;

	[SerializeField]
	private string vertical = "Vertical";

	[SerializeField]
	private string horizontal = "Horizontal";
	
	void Awake ()
	{
		// get the car controller
		car = GetComponent<CarController>();
		nitro = false;
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

		if (Input.GetButton ("Jump")) {
			if (!nitro) {
				nitro = true;
				this.car.Boost (speedFactor);
			}
		} else {
			nitro = false;
		}
	}
}
