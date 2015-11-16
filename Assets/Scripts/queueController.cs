using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class queueController : MonoBehaviour {

    public bool[] queueSpots = new bool[10];
    public Vector2[] queuePositions = new Vector2[10];
    public GameObject activePerson = new GameObject();
    

	// Use this for initialization
	void Start () {

        float yPos = 0;
        for (int i = 0; i < 10; i++)
        {
            queueSpots[i] = false;

            queuePositions[i].x = 0;
            queuePositions[i].y = yPos;

            yPos += (float)0.5;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Vector2 getNextQueuePosition()
    {
        int freePos = -1;
        for (int i = 0; i < 10; i++)
        {
            if (queueSpots[i] == false)
            {
                freePos = i;
                queueSpots[i] = true;
                break;
            }
        }

        return queuePositions[freePos];
    }

    public Vector2 moveForward(int currentPosition)
    {        
        queueSpots[currentPosition] = false;
        if (currentPosition >= 0)
            return queuePositions[currentPosition - 1];
        else
            return new Vector2(0, 0);
    }
}
