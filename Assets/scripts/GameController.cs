using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    // Use this for initialization
    float maxwidth;
    public GameObject []objs;
    Vector3 spawnposition;
    Quaternion spawnrotation;
    public Dropdown speedopt;
    float timer;
    public float delay = 0.3f;

    void Awake()
    {
        speedopt.value = 1;
    }

    void Start()
    {
        Camera.main.aspect = 800f / 480f;
        delay = 0.3f;
        timer = delay;
        StartCoroutine(spawn());
    }

    public void changespeed()
    {
        if (speedopt.value == 0)
        {
            PlayerPrefs.SetFloat("speed", 5f);
        }
        else if (speedopt.value == 1)
        {
            PlayerPrefs.SetFloat("speed", 10f);
        }
        else if (speedopt.value == 2)
        {
            PlayerPrefs.SetFloat("speed", 15f);
        }

    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(objs[3], new Vector3(10f, -4.2f), transform.rotation);
            if(PlayerPrefs.GetFloat("speed",2.5f) == 5f)
            {
                delay = 0.3f;
            }
            if (PlayerPrefs.GetFloat("speed", 2.5f) == 10f)
            {
                delay = 0.2f;
            }
            if (PlayerPrefs.GetFloat("speed", 2.5f) == 15f)
            {
                delay = 0.1f;
            }
            if (PlayerPrefs.GetFloat("speed", 2.5f) == 2.5f)
            {
                delay = 0.3f;
            }
            timer = delay;
        }
    }

    IEnumerator spawn()
    {
        Vector3 current = gameObject.transform.position;
        spawnrotation = Quaternion.identity;
        while (true)
        {
            int num = Random.Range(0, objs.Length-1);
            switch(num)
            {
                case 0: spawnposition = new Vector3(10f, -3f);break;
                case 1:spawnposition = new Vector3(10f,-1.5f*Random.Range(0,2));break;
                case 2:spawnposition = new Vector3(10f,-4.2f);break;
            }
            
            Instantiate(objs[num], spawnposition, spawnrotation);
            if (PlayerPrefs.GetFloat("speed", 2.5f) == 5f)
            {
                yield return new WaitForSeconds(2.0f);
            }
            if (PlayerPrefs.GetFloat("speed", 2.5f) == 10f)
            {
                yield return new WaitForSeconds(1.5f);
            }
            if (PlayerPrefs.GetFloat("speed", 2.5f) == 15f)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (PlayerPrefs.GetFloat("speed", 2.5f) == 2.5f)
            {
                yield return new WaitForSeconds(2.0f);
            }
            
        }
    }
}
