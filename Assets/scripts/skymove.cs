using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skymove : MonoBehaviour {

    public float speed = 0.05f;
    Vector2 offset;

    void Start()
    {
        speed = 0.05f;
    }


    void Update()
    {
        offset = new Vector2(Time.time * speed,0);

        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
