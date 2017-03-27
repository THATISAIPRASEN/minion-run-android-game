using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour {

    public GameObject[] objs;
    public float delay = 1f;
    float timer;
    Vector3 objPos;

    // Use this for initialization
    void Start()
    {
        timer = delay;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            int objNo = Random.Range(0, objs.Length - 1);
            switch(objNo)
            {
                case 0: objPos = new Vector3(10f, -3f, -5f);break;
                
            }
            Instantiate(objs[objNo], objPos, transform.rotation);
            delay = Random.Range(2f, 10f);
            timer = delay;
        }

    }

}
