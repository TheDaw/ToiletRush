using UnityEngine;
using System.Collections;

public class PersonMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.Translate(new Vector3(0, -Time.deltaTime));
	
	}
}
