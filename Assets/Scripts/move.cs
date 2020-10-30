using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class move : NetworkBehaviour
{
    public Rigidbody rb;
    public float speed = 10;
    public Camera cam;

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        Camera.main.GetComponent<CameraFollow>().target = transform; //Fix camera on "me"

    }
    void Awake()
    {
        if (!isLocalPlayer)
        {
            cam.enabled = false;
        }
    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 FORWARD = transform.TransformDirection(Vector3.forward);

        transform.localPosition += FORWARD * v;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speed - .2f;
        }
        else
        {
            speed = 20;
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(0.0f, -speed / 20, 0.0f, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(0.0f, speed / 20, 0.0f, Space.Self);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            rb.velocity = new Vector3(0,0,0);
        }
    }
}
