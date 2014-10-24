using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Accelerator : MonoBehaviour {

    public float speedFactor = 2;

    void OnTriggerEnter(Collider other)
    {
        Accelerable accelerable = other.GetComponentInParent<Accelerable>();
        if (accelerable)
        {
            StartCoroutine(accelerable.Accelerate(this.speedFactor));
        }
    }
}
