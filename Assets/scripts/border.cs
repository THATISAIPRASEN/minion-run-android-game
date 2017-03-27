using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D obj)
    {
        Destroy(obj.gameObject);
    }
}
