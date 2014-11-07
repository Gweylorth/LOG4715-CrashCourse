using UnityEngine;
using System.Collections;

public class SpeedText : MonoBehaviour
{
	public GUIText speedText;

	// Update is called once per frame
	void Update ()
	{
        GameObject go = GameObject.Find("Joueur 1");
        if (!go)
        {
            return;
        }
		CarController player = go.GetComponent<CarController> ();
        if (!player)
        {
            return;
        }
		speedText.text = ((int)player.CurrentSpeed).ToString () + " km/h";
	}
}