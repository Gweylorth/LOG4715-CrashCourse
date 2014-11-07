using UnityEngine;
using System.Collections;

public class HPText : MonoBehaviour
{
	public GUIText hpTextP1;
	public GUIText hpTextP2;
	
	// Update is called once per frame
	void Update ()
	{
		GameObject goP1 = GameObject.Find("Joueur 1");
		if (goP1)
		{
			Destructible playerP1 = goP1.GetComponent<Destructible>();
			if (playerP1)
			{
				this.hpTextP1.text = "PV : " + playerP1.healthPoints.ToString () + "/" + playerP1.maxHealthPoints.ToString ();
				
				if (playerP1.healthPoints <= playerP1.maxHealthPoints * 0.2) {			
					this.hpTextP1.color = Color.red;
				} else {
					this.hpTextP1.color = Color.green;
				}
			}
		}


		GameObject goP2 = GameObject.Find("Joueur 2");
		if (goP2)
		{
			Destructible playerP2 = goP2.GetComponent<Destructible>();
			if (playerP2)
			{
				this.hpTextP2.text = "PV : " + playerP2.healthPoints.ToString () + "/" + playerP2.maxHealthPoints.ToString ();
				
				if (playerP2.healthPoints <= playerP2.maxHealthPoints * 0.2) {			
					this.hpTextP2.color = Color.red;
				} else {
					this.hpTextP2.color = Color.green;
				}
			}
		}

	}
}