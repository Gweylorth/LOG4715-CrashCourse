using UnityEngine;
using System.Collections;

public class Style : MonoBehaviour {

	private int points;
	public GUIText textPoint;
	public int ajoutFrolage;

	void Start() {
		points = 0;	
	}

	void Update ()
	{
		textPoint.text = "Score : " + points;
	}

	void OnTriggerEnter(Collider other)	{
		if (other.tag == "Style")
		{
			points += ajoutFrolage;
		}
	}
}
