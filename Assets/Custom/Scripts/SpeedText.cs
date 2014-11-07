using UnityEngine;
using System.Collections;

public class SpeedText : MonoBehaviour
{
	public GUIText speedTextP1;
	public GUIText speedTextP2;

	// Update is called once per frame
	void Update ()
	{
		GameObject goP1 = GameObject.Find("Joueur 1");
		if (goP1)
		{
			CarController playerP1 = goP1.GetComponent<CarController>();
			if (playerP1)
			{
				speedTextP1.text = ((int)playerP1.CurrentSpeed).ToString () + " km/h";
			}
		}
		
		GameObject goP2 = GameObject.Find("Joueur 2");
		if (goP2)
		{
			CarController playerP2 = goP2.GetComponent<CarController>();
			if (playerP2)
			{
				speedTextP2.text = ((int)playerP2.CurrentSpeed).ToString () + " km/h";
			}
		}
	}
}