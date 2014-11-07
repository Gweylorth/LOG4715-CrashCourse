using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {

    public string tagToFind = "Player";
    public int sectionId;

    void OnTriggerEnter(Collider other)
    {
        Transform baseParent = other.transform.parent.parent;
        if (baseParent.tag != this.tagToFind)
        {
            return;
        }

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

    void OnTriggerExit(Collider other)
    {
        Transform baseParent = other.transform.parent.parent;
        if (baseParent.tag != this.tagToFind)
        {
            return;
        }

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
