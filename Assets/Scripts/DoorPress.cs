using UnityEngine;
using System.Collections;

public class DoorPress : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseDown()
    {
        this.gameObject.transform.Translate(new Vector3(0, 1));
    }
}
