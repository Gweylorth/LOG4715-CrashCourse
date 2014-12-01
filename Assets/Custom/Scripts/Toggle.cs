using UnityEngine;
using System.Collections;

public class Toggle : MonoBehaviour {

    public Material onMaterial;
    public Material offMaterial;
    public TogglableDoor target;

    private bool state = false;

    // Called when the collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Style")
        {
            this.state = !this.state;
            this.GetComponent<MeshRenderer>().material = (this.state) ? this.onMaterial : this.offMaterial;
            // Make noise
            AudioSource audio = this.gameObject.GetComponent<AudioSource>();
            if (audio)
            {
                audio.Play();
            }
            this.target.SwitchState();
        }
    }
}
