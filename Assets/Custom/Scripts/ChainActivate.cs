using UnityEngine;
using System.Collections;

public class ChainActivate : MonoBehaviour {

    [SerializeField]
    private GameObject[] children;

    void Awake()
    {
        foreach (GameObject child in this.children)
        {
            child.SetActive(true);
        }
    }
}
