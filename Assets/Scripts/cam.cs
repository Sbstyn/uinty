using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class cam : MonoBehaviour
{
    void Start()
    {
        GetComponentInChildren<Camera>().enabled = false;
    }
}