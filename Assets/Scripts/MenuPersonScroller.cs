﻿using UnityEngine;
using System.Collections;

public class MenuPersonScroller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(0,-1,0) * Time.deltaTime);

        if (transform.position.y < -8)
            Destroy(this.gameObject);
    }
}
