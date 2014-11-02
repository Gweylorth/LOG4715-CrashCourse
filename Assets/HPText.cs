using UnityEngine;
using System.Collections;

public class HPText : MonoBehaviour {

	public GUIText hpText;
	
	// Update is called once per frame
	void Update () {
		Destructible player = GameObject.Find("Joueur 1").GetComponent<Destructible>();
		hpText.text = "PV : " + player.healthPoints.ToString() + "/" + player.maxHealthPoints.ToString();
	}
}