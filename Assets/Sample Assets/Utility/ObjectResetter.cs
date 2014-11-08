using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectResetter : MonoBehaviour {

	Vector3 originalPosition;
	Quaternion originalRotation;
	List<Transform> originalStructure;

    public List<bool> SectionsPresence { get; set; } 

	// Use this for initialization
	void Start () {
		originalStructure = new List<Transform>(GetComponentsInChildren<Transform>());
		originalPosition = transform.position;
		originalRotation = transform.rotation;
        this.SectionsPresence = new List<bool> { true };
	}

	public void DelayedReset (float delay) {
		StartCoroutine(ResetCoroutine(delay));
	}

	IEnumerator ResetCoroutine (float delay)
	{
		yield return new WaitForSeconds(delay);

		// remove any gameobjects added (fire, skid trails, etc)
		foreach (var t in GetComponentsInChildren<Transform>())
		{
			if (!originalStructure.Contains(t))
			{
				t.parent = null;
			}
		}

		transform.position = originalPosition;
		transform.rotation = originalRotation;
		if (rigidbody)
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
		
		Destructible destructible = this.gameObject.GetComponent<Destructible>();
		if (destructible)
		{
			destructible.healthPoints = destructible.maxHealthPoints;
		}

		SendMessage("Reset");
	}
}

