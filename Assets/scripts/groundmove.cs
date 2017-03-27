using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundmove : MonoBehaviour {

    //public float speed = 0.5f;
    //Vector2 offset;
    float timer;
    public float speed = 8f;
    void Start()
    {
        speed = PlayerPrefs.GetFloat("speed", 8f);
    }


    void Update()
    {
        speed = PlayerPrefs.GetFloat("speed", 8f);
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
    }
}
