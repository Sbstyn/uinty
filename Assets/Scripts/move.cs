using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class move : NetworkBehaviour
{
    public Rigidbody rb;
    public float speed = 0;
    public Camera cam;
    public Text speedmeter;
    public bool isOnGround;

    public int model = 0;

    //public Camera HUDCAM;

    /*public override void OnStartLocalPlayer()
    {
        //GetComponent<MeshRenderer>().material.color = Color.blue;
        Camera.main.GetComponent<CameraFollow>().target = transform; //Fix camera on "me"

    }*/
    private void Start()
    {
        GetComponentInChildren<Camera>().enabled = true;
    }
    void Awake()
    {
        //HUDCAM.enabled = false;
        if (!isLocalPlayer)
        {
            cam.enabled = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (model == 1)
            {
                model = 0;
            }
            else
            {
                model = 1;
            }
        }
        if (isOnGround == false)
        {
            if (speed >= 0f)
            {
                speed = speed - .02f;
            }
            else if (speed <= 0f)
            {
                speed = speed + .02f;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, transform.position.y + 10, transform.position.z);
            rb.velocity = new Vector3(0, 0, 0);
            gameObject.transform.rotation = new Quaternion(0, gameObject.transform.rotation.y, 0, 0);
        }

        if (gameObject.transform.position.y < -20)
        {
            speed = 0;
            gameObject.transform.position = new Vector3(0, 12, 0);
            rb.velocity = new Vector3(0, 0, 0);
            gameObject.transform.rotation = new Quaternion(0, gameObject.transform.rotation.y, 0, 0);
        }

        if (!isLocalPlayer)
        {
            return;
        }

        transform.position += transform.forward * Time.deltaTime * speed;

        if (isOnGround == true)
        {

            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                if (speed == 0)
                {
                    speed = -.1f;
                }
                else
                {
                    if (speed > -10)
                    {
                        speed = speed - .05f;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                if (speed == 0)
                {
                    speed = .1f;
                }
                else
                {
                    if (speed < 50)
                    {
                        speed = speed + .05f;
                    }
                }
            }
            else if (speed >= 0f)
            {
                speed = speed - .03f;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (speed >= .5f)
                {
                    speed = speed - .2f;
                }
                else if (speed <= -.5f)
                {
                    speed = speed + .2f;
                }
                else
                {
                    speed = 0;
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                if (speed < 20)
                {
                    gameObject.transform.Rotate(0.0f, -speed / 10, 0.0f, Space.Self);
                }
                else
                {
                    gameObject.transform.Rotate(0.0f, -2, 0.0f, Space.Self);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (speed < 20)
                {
                    gameObject.transform.Rotate(0.0f, speed / 10, 0.0f, Space.Self);
                }
                else
                {
                    gameObject.transform.Rotate(0.0f, 2, 0.0f, Space.Self);
                }
            }
        }
        
        GetComponentInChildren<Camera>().enabled = true;

        int finalspeed = (int) speed * 2;
        speedmeter.text = finalspeed.ToString();

        /*float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 FORWARD = transform.TransformDirection(Vector3.forward);

        transform.localPosition += FORWARD * v;*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            rb.velocity = new Vector3(0,0,0);
            isOnGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isOnGround = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.transform.tag == "ground")
        {
            isOnGround = true;
            Debug.Log("pp");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isOnGround = false;
    }
}
