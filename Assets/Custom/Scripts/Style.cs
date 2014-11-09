using UnityEngine;
using System.Collections;

// Manage style points
public class Style : MonoBehaviour {
	
	// The car
	private CarController car;
	// Minimal threshold of speed for earning points by brushing
	private float seuilMinSpeed;
	// Minimal threshold of speed for earning points by overspeeding
	private float seuilMaxSpeed;
	// Number of points
	private int points;
	// Boolean for brushing other car
	private bool frolage;
	// Counter points
	private int cptPoints;
	
	// Method to set the counter
	public int CptPoints
	{
		set { this.cptPoints = value; }
	}

	// Style points text
	public GUIText textPoint;
	// Factor for the thresholds by brushing
	public float factorMinSpeed;
	// Factor for the thresholds by overspeeding
	public float factorMaxSpeed;
	// Thresholds of points for earning a boost
	public int seuilPointsBoost;
	
	// Number of points for a brush
	public int ajoutFrolage;
	// Number of points for an overspeeding
	public int ajoutVitesseFolle;
	// Number of points for beeing in the air
	public int ajoutEnLAir;
	// Number of points for causing an explosion
	public int ajoutExplosion;

	// Use this for initialization
	void Start() {
		// Initialize values
		this.points = 0;
		this.cptPoints = 0;
		this.car = this.GetComponentInParent<CarController>();
		this.seuilMinSpeed = this.car.MaxSpeed * this.factorMinSpeed;
		this.seuilMaxSpeed = this.car.MaxSpeed * this.factorMaxSpeed;
	}

	// Called when the collider enters the trigger
	void OnTriggerEnter(Collider other)	{
		if (other.tag == "Style") {
			this.frolage = true;
		}
	}

	// Called when the collider has stopped touching the trigger
	void OnTriggerExit(Collider other)	{
		if (other.tag == "Style") {
			this.frolage = false;
		}
	}

	// Update is called once per fixed framerate frame
	void FixedUpdate() {
		// If the speed of the car is enough
		if (this.car.CurrentSpeed >= this.seuilMinSpeed) {
			// If brushing
			if (frolage) {
				this.points += this.ajoutFrolage;
				this.cptPoints += this.ajoutFrolage;
			}
			// If in the air
			if(!this.car.AnyOnGround) {
				this.points += this.ajoutEnLAir;
				this.cptPoints += this.ajoutEnLAir;
			}
		}
		// If overspeeding
		if (this.car.CurrentSpeed >= this.seuilMaxSpeed) {
			this.points += this.ajoutVitesseFolle;
			this.cptPoints += this.ajoutVitesseFolle;
		}
		// Display style points
		this.textPoint.text = "Score : " + this.points;

		// If enough points, add a boost
		if(this.cptPoints > seuilPointsBoost) {
			this.cptPoints -= seuilPointsBoost;
			Boost carBoost = this.gameObject.GetComponentInParent<Boost>();
			if(carBoost) {
				carBoost.AddBoost();
			}
		}
	}

	// Add points for causing an explosion
	public void AddExplosionPoints() {
		this.points += this.ajoutExplosion;
		this.cptPoints += this.ajoutExplosion;
	}
}
