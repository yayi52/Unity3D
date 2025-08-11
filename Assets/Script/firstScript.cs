using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class firstScript : MonoBehaviour
{
    public string s;
    public int i;
    public float f;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("哈囉，握兒得");
        Debug.Log(s);
        s = "我愛弟弟";
        Debug.Log(s);
        Debug.Log(cube);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
