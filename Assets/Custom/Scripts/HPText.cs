using UnityEngine;
using System.Collections;

public class HPText : MonoBehaviour
{
	public GUIText hpText;
	
	// Update is called once per frame
	void Update ()
	{
        GameObject go = GameObject.Find("Joueur 1");
        if (!go)
        {
            return;
        }
		Destructible player = go.GetComponent<Destructible>();
        if (!player)
        {
            return;
        }
		hpText.text = "PV : " + player.healthPoints.ToString () + "/" + player.maxHealthPoints.ToString ();
	}
}