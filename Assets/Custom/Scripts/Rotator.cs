using UnityEngine;
using System.Collections;

// Apply rotation on nuts
public class Rotator : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0, 80, 0) * Time.deltaTime);
	}
}
