using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Accelerator : MonoBehaviour {

    public float speedFactor = 5;

    void OnTriggerEnter(Collider other)
    {
        Accelerable accelerable = other.GetComponentInParent<Accelerable>();
        if (accelerable)
        {
            StartCoroutine(accelerable.Accelerate(this.speedFactor));
            AudioSource audio = this.gameObject.GetComponent<AudioSource>();
            if (audio)
            {
                audio.Play();
            }
        }
    }
}
