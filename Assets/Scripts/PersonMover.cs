using UnityEngine;
using System.Collections;

public class PersonMover : MonoBehaviour {

    public bool selected = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.Translate(new Vector3(0, -Time.deltaTime));
	
	}

    void OnMouseDown()
    {
        selected = true;       
    }
}
