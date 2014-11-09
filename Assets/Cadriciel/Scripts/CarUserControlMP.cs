using UnityEngine;

[RequireComponent(typeof(CarController))]
public class CarUserControlMP : MonoBehaviour
{
	private CarController car;  // the car controller we want to use
	private bool boost = false;
	
	public float speedFactor;

	[SerializeField]
	private string vertical = "Vertical";
	
	[SerializeField]
	private string horizontal = "Horizontal";
	
	[SerializeField]
	private string jump = "Jump";
	
	void Start ()
	{
		// get the car controller
		car = GetComponent<CarController>();
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

		if (Input.GetButton (jump)) {
			if (!boost) {
				Boost carBoost = this.gameObject.GetComponent<Boost>();
				if(carBoost) {
					if(carBoost.NbBoost > 0) {
						boost = true;
						carBoost.SubBoost();
						this.car.Boost (speedFactor);
												
						Style carStyle = this.gameObject.GetComponentInChildren<Style>();
						carStyle.CptPoints = 0;
					}
				}
			}
		} else {
			boost = false;
		}
	}
}
