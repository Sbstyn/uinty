using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class main : MonoBehaviour
{
    public GameObject landmine;
    public float Spawnpoint = 1.2f;
    public float tim = 1f;
    public bool able2spawn = true;
    public bool able2destroy = false;
    public int rand;
    public int aim;
    public int song = 0;

    public AudioSource Asource;
    public AudioClip[] AClip;
    void Start()
    {
        GameObject[] mines = GameObject.FindGameObjectsWithTag("mine");
        for (int i = 0; i < mines.Length; i++)
        {
            Destroy(mines[i]);
        }
        Debug.Log(Screen.width);
        StartCoroutine(Audio());
    }
    IEnumerator Audio()
    {
        Asource.Stop();
        Asource.loop = true;
        yield return new WaitForSeconds(4.5f);
        Asource.PlayOneShot(AClip[song]);
    }
    void Update()
    {
        StartCoroutine(Spawn());

        if (Input.GetMouseButtonDown(0) || Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                aim = 1;
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                aim = 2;
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                aim = 3;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                aim = 4;
            }
            else if (Input.mousePosition.x < Screen.width / 4 && Input.GetMouseButtonDown(0))
            {
                aim = 1;
            }
            else if (Input.mousePosition.x > Screen.width / 4 && Input.mousePosition.x < Screen.width / 4 * 2 && Input.GetMouseButtonDown(0))
            {
                aim = 2;
            }
            else if (Input.mousePosition.x > Screen.width / 4 * 2 && Input.mousePosition.x < Screen.width / 4 * 3 && Input.GetMouseButtonDown(0))
            {
                aim = 3;
            }
            else if (Input.mousePosition.x > Screen.width / 4 * 3 && Input.GetMouseButtonDown(0))
            {
                aim = 4;
            }
        }
        if(Input.GetMouseButtonUp(0) && !Input.anyKey)
        {
            aim = 0;
        }
    }
    IEnumerator Spawn()
    {
        if (able2spawn == true)
        {
            able2spawn = false;
            yield return new WaitForSeconds(tim);
            rand = Random.Range(-2, 2);
            if(rand == 0)
            {
                Instantiate(landmine, new Vector3(0, 1, 55), Quaternion.identity);
                landmine.transform.position = new Vector3(0, 1, 55);
            }
            else if (rand == -1)
            {
                Instantiate(landmine, new Vector3(-1.2f, 1, 55), Quaternion.identity);
                landmine.transform.position = new Vector3(-1.2f, 1, 55);
            }
            else if (rand == -2)
            {
                Instantiate(landmine, new Vector3(-2.4f, 1, 55), Quaternion.identity);
                landmine.transform.position = new Vector3(-2.4f, 1, 55);
            }
            else if (rand == 1)
            {
                Instantiate(landmine, new Vector3(1.2f, 1, 55), Quaternion.identity);
                landmine.transform.position = new Vector3(1.2f, 1, 55);
            }
            //Instantiate(landmine, new Vector3(rand * Spawnpoint, 1, 55), Quaternion.identity);
            able2spawn = true;
        }
    }
    public void OnRestart()
    {
        if(song == AClip.Length)
        {
            song = 0;
        }
        else
        {
            song++;
        }
        Start();
    }
}