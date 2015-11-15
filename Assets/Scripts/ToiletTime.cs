using UnityEngine;
using System.Collections;

public class ToiletTime : MonoBehaviour {

    public float waitPatience;
    public float toiletTime;
    public bool inQueue = false;
    public bool usingToilet = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (usingToilet)
        {
            toiletTime = toiletTime - Time.deltaTime;
        }

        if (toiletTime < 0)
        {
            //trigger leave
        }
        
	}
}
