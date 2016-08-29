﻿using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }
}
