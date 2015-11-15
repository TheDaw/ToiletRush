using UnityEngine;
using System.Collections;

public class PersonNavigation : MonoBehaviour {

    public enum personStates { moveToQueue, queue, moveToRoom, inRoom, leaving}
    public bool selected = false;
    personStates state = personStates.moveToQueue;    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        switch (state)
        {
            case personStates.moveToQueue:
                break;
            case personStates.queue:
                break;
            case personStates.moveToRoom:
                break;
            case personStates.inRoom:
                break;
            case personStates.leaving:
                break;
        }            
	
	}

    void OnMouseDown()
    {
        selected = true;
    }

    void moveToQueueUpdate()
    {

    }

    void queueUpdate()
    { }

    void selectedUpdate()
    { }

    void inRoomUpdate()
    {

    }

    void leaveUpdate()
    {

    }
}
