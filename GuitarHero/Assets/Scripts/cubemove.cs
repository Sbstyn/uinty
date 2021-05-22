using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemove : MonoBehaviour
{
    public float speed = .1f;
    void Update()
    {
        gameObject.transform.Translate(Vector3.back * speed);
        if(gameObject.transform.position.z < -20)
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.z < -6.8f && gameObject.transform.position.z > -7.9f)
        {
            if (gameObject.transform.position.x == -2.4f && GameObject.Find("Cylinder").GetComponent<main>().aim == 1)
            {
                Destroy(gameObject);
            }
            else if (gameObject.transform.position.x == -1.2f && GameObject.Find("Cylinder").GetComponent<main>().aim == 2)
            {
                Destroy(gameObject);
            }
            else if (gameObject.transform.position.x == 0 && GameObject.Find("Cylinder").GetComponent<main>().aim == 3)
            {
                Destroy(gameObject);
            }
            else if (gameObject.transform.position.x == 1.2f && GameObject.Find("Cylinder").GetComponent<main>().aim == 4)
            {
                Destroy(gameObject);
            }
        }
    }
}
