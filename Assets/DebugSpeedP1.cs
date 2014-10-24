using UnityEngine;
using System.Collections;

public class DebugSpeedP1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CarController player = GameObject.Find("Joueur 1").GetComponent<CarController>();
        foreach (GUIText guit in this.gameObject.GetComponentsInChildren<GUIText>()) {
            if (guit.gameObject.name == "Speed")
            {
                guit.text = "Speed: " + ((int)player.CurrentSpeed).ToString();
            }
        }
	}
}
