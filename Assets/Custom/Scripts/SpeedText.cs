using UnityEngine;
using System.Collections;

public class SpeedText : MonoBehaviour {

	public GUIText speedText;

	// Update is called once per frame
	void Update () {
		CarController player = GameObject.Find("Joueur 1").GetComponent<CarController>();
		speedText.text = ((int)player.CurrentSpeed).ToString() + " km/h";
	}
}