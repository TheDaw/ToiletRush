using UnityEngine;
using System.Collections;

public class RoomCapacity : MonoBehaviour {

    public int capacity = 10;
    public int currentUserCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void personEntered()
    {
        currentUserCount++;
    }

    void personLeft()
    {
        currentUserCount--;
    }
}
