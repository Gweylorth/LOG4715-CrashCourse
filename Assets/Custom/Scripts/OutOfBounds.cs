using UnityEngine;
using System.Collections;

// Replace cars on track
public class OutOfBounds : MonoBehaviour {

	// Tag to find players
    public string tagToFind = "Player";
	// Id of the section where the car is
    public int sectionId;

	// Called when the collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
		// Find the car
        Transform baseParent = other.transform.parent.parent;
        if (baseParent.tag != this.tagToFind)
        {
            return;
        }

		// Configure booleans to prove that car is on track
        ObjectResetter resetter = baseParent.GetComponent<ObjectResetter>();
        if (resetter)
        {
            if (resetter.SectionsPresence.Count <= this.sectionId)
            {
                resetter.SectionsPresence.Add(true);
            }
            else
            {
                resetter.SectionsPresence[this.sectionId] = true;
            }
        }
    }

	// Called when the collider has stopped touching the trigger
    void OnTriggerExit(Collider other)
    {
		// Find the car
        Transform baseParent = other.transform.parent.parent;
        if (baseParent.tag != this.tagToFind)
        {
            return;
        }

		// Search for booleans to know if car quits track
        ObjectResetter resetter = baseParent.GetComponent<ObjectResetter>();
        if (resetter)
        {
            resetter.SectionsPresence[this.sectionId] = false;
            foreach (bool section in resetter.SectionsPresence)
            {
                if (section)
                {
                    return;
                }
            }
        }

		// Replace the car on the respawn point
        Transform respawn = this.transform.FindChild("RespawnPoint");
        baseParent.position = respawn.position;
        baseParent.rotation = respawn.rotation;
        if (rigidbody)
        {
            baseParent.rigidbody.velocity = Vector3.zero;
            baseParent.rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
