using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Accelerator : MonoBehaviour {

    public float speedFactor = 2;

    void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Colliding");
        Accelerable accelerable = other.GetComponentInParent<Accelerable>();
        if (accelerable)
        {
            Debug.LogWarning("Accelerate !");
            accelerable.Accelerate(this.speedFactor);
        }
    }
}
