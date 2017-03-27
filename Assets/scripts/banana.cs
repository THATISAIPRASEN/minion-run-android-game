using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class banana : MonoBehaviour
{

    public float speed = 8f;
    // Use this for initialization
    void Start()
    {
        speed = PlayerPrefs.GetFloat("speed",8f);
    }

    

    // Update is called once per frame
    void Update()
    {
        speed = PlayerPrefs.GetFloat("speed", 8f);
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
    }
}