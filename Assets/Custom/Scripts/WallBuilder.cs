using UnityEngine;
using System.Collections;

public class WallBuilder : MonoBehaviour {

    public Transform brick;
    public int repeats;

    void Start()
    {
        for (int y = 0; y < repeats; y++)
        {
            for (int x = 0; x < repeats; x++)
            {
                Instantiate(brick, new Vector3(this.transform.position.x + x, this.transform.position.y + y, 0), this.transform.rotation);
            }
        }
    }
}
