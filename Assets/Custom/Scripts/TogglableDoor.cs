using UnityEngine;
using System.Collections;

public class TogglableDoor : MonoBehaviour {

    private bool state = false;
    private float currentAngle = 0;
    private Transform leftSide;
    private Transform rightSide;

    void Start()
    {
        this.leftSide = this.transform.FindChild("LeftSide");
        this.rightSide = this.transform.FindChild("RightSide");
    }

    void FixedUpdate()
    {

        float step = 50 * Time.deltaTime;
        if (this.state && this.currentAngle < 90)
        {
            this.leftSide.FindChild("Grid").Rotate(this.leftSide.FindChild("Base").right, -step);
            this.rightSide.FindChild("Grid").Rotate(this.rightSide.FindChild("Base").right, -step);
            this.currentAngle += step;
        }
        if (!this.state && this.currentAngle > 0)
        {
            this.leftSide.FindChild("Grid").Rotate(this.leftSide.FindChild("Base").right, step);
            this.rightSide.FindChild("Grid").Rotate(this.rightSide.FindChild("Base").right, step);
            this.currentAngle -= step;
        }
    }

    public void SwitchState()
    {
        this.state = !this.state;
    }
}
