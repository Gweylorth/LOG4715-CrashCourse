using UnityEngine;
using System.Collections;

// Manage accelarators on track
public class Accelerator : MonoBehaviour {

	// Speed factor applied on car
    public float speedFactor = 5;

	// Called when the collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
		// Find the car
        Accelerable accelerable = other.GetComponentInParent<Accelerable>();
        if (accelerable)
        {
			// Accelerate the car
            StartCoroutine(accelerable.Accelerate(this.speedFactor));
			// Make noise
            AudioSource audio = this.gameObject.GetComponent<AudioSource>();
            if (audio)
            {
                audio.Play();
            }
        }
    }
}
