using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : MonoBehaviour {
    Transform target;
    float speed = 30.0f;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("Target").transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(target.position, Vector3.up,speed*Time.deltaTime);
    }
}
