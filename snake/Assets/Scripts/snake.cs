using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    public GameObject snakebodyprefab;
    public GameObject snke;
    public GameObject fruit;
    public GameObject go;

    public int count = 1;
    public int parts = 0;
    public int dir;
    public int going;
    public float speed = 1;
    public bool start = true;
    public Vector3 headpos;
    public Vector3 pos2;

    void Start()
    {
        create();
        StartCoroutine(Coroutines());
        fruit.transform.position = new Vector3(Random.Range(-16, 16), Random.Range(-9, 9));
    }

    void Startter()
    {
        StartCoroutine(Coroutines());
    }

    IEnumerator Coroutines()
    {
        yield return new WaitForSeconds(.1f);
        move();

        if (parts > 1)
        {
            while (parts > count)
            {
                headpos = snke.transform.position;
                pos2 = gameObject.transform.Find("p." + count).transform.position;
                gameObject.transform.Find("p." + count).transform.position = headpos;

                count++;
            }
        }
            
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            dir = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir = 3;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir = 4;
        }

        if (gameObject.transform.position == fruit.transform.position)
        {
            create();
            fruit.transform.position = new Vector3(Random.Range(-16, 16), Random.Range(-9, 9));
        }
    }
    public void create()
    {
        if (parts == 0)
        {
            go = Instantiate(snakebodyprefab, new Vector3(0, 0, 0), Quaternion.identity);
            go.name = "head";
            go.transform.parent = GameObject.Find("snake").transform;
            parts += 1;
        }
        else
        {
            go = Instantiate(snakebodyprefab, snke.transform.position, Quaternion.identity);
            go.name = ("p." + parts.ToString());
            go.transform.parent = GameObject.Find("snake").transform;
            parts += 1;
        }
    }

    public void move()
    {
        if (dir == 1)
        {
            snke.transform.Translate(Vector3.up * speed);
        }
        if (dir == 2)
        {
            snke.transform.Translate(Vector3.down * speed);
        }
        if (dir == 3)
        {
            snke.transform.Translate(Vector3.left * speed);
        }
        if (dir == 4)
        {
            snke.transform.Translate(Vector3.right * speed);
        }
        Startter();
    }
}