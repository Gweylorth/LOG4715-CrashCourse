using UnityEngine;
using System.Collections;

// Display speed of the car
public class SpeedText : MonoBehaviour {

	// Text speed for player 1
	public GUIText speedTextP1;
	// Text speed for player 2
	public GUIText speedTextP2;

	// Update is called once per frame
	void Update ()
	{
		// Find player 1
		GameObject goP1 = GameObject.Find("Joueur 1");
		if (goP1)
		{
			// Get the car 1
			CarController playerP1 = goP1.GetComponent<CarController>();
			if (playerP1)
			{
				// Display speed
				speedTextP1.text = ((int)playerP1.CurrentSpeed).ToString () + " km/h";
			}
		}
		
		// Find player 2
		GameObject goP2 = GameObject.Find("Joueur 2");
		if (goP2)
		{
			// Get the car 2
			CarController playerP2 = goP2.GetComponent<CarController>();
			if (playerP2)
			{
				// Display speed
				speedTextP2.text = ((int)playerP2.CurrentSpeed).ToString () + " km/h";
			}
		}
	}
}