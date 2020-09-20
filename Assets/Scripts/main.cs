using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    public GameObject player;
    public GameObject fin;
    public GameObject track;

    public Text dectxt;
    public Text postxt;

    public Camera cam;
    public Slider camsize;
    public Slider speed;

    public int x;
    public int movementSpeed = 1;
    public int dec = 0;
    public int started = 1;
    public bool isstarted = true;

    private GameObject clones;

    void Start()
    {
        StartCoroutine(Coroutines());
    }

    IEnumerator Coroutines()
    {
        if (started == 1)
        {
            yield return new WaitForSeconds(.05f * speed.value);
            if (isstarted == true)
            {
                mmain();
            }
            else
            {
                StartCoroutine(Coroutines());
            }
        }
    }
    public void mmain()
    {
        x = Random.Range(0, 4);
        if (x == 0)
        {
            player.transform.Translate(Vector3.up * movementSpeed);
            clones = Instantiate(track, new Vector3(player.transform.position.x, player.transform.position.y - .5f), Quaternion.identity);
            clones.tag = "clone";
        }
        else if (x == 1)
        {
            player.transform.Translate(Vector3.right * movementSpeed);
            clones = Instantiate(track, new Vector3(player.transform.position.x - .5f, player.transform.position.y), transform.rotation * Quaternion.Euler(0f, 0f, 90f));
            clones.tag = "clone";
        }
        else if (x == 2)
        {
            player.transform.Translate(Vector3.down * movementSpeed);
            clones = Instantiate(track, new Vector3(player.transform.position.x, player.transform.position.y + .5f), Quaternion.identity);
            clones.tag = "clone";
        }
        else if (x == 3)
        {
            player.transform.Translate(Vector3.left * movementSpeed);
            clones = Instantiate(track, new Vector3(player.transform.position.x + .5f, player.transform.position.y), transform.rotation * Quaternion.Euler(0f, 0f, 90f));
            clones.tag = "clone";
        }

        dec += 1;

        dectxt.text = "Decisions: " + dec.ToString();
        postxt.text = "Position x: " + player.transform.position.x + " y: " + player.transform.position.y;

        if (player.transform.position.x == 0 && player.transform.position.y == 0)
        {
            postxt.text = "SUCCESS! (Click here to reset) " + "Position x: " + player.transform.position.x + " y: " + player.transform.position.y;
            StartCoroutine(Coroutines());
            isstarted = false;
        }
        else
        {
            StartCoroutine(Coroutines());
        }
    }

    public void gameStart()
    {
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones)
            {
                Destroy(clone);
            }
        started = 0;
        StartCoroutine(Coroutines());
        player.transform.position = new Vector3(6, -1);
        dec = 0;
        started = 1;
        isstarted = true;
    }

    public void CamSize()
    {
        cam.orthographicSize = 5 * camsize.value;
    }
}
