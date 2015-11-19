using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class queueController : MonoBehaviour {

    public bool[] queueSpots = new bool[50];
    public Vector2[] queuePositions = new Vector2[50];
    public GameObject activePerson = new GameObject();
    public int queueCount = 0;
    public int score = 0;


    // Use this for initialization
    void Start() {

        float yPos = 0;
        for (int i = 0; i < 50; i++)
        {
            queueSpots[i] = false;

            queuePositions[i].x = 0;
            queuePositions[i].y = yPos;

            yPos += (float)1.25;
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public Vector3 getNextQueuePosition()
    {
        int freePos = -1;
        for (int i = 0; i < 50; i++)
        {
            if (queueSpots[i] == false)
            {
                freePos = i;
                queueSpots[i] = true;
                break;
            }
        }
        Vector3 info = new Vector3();
        info.x = queuePositions[freePos].x;
        info.y = queuePositions[freePos].y;
        info.z = freePos;

        return info;
    }

    public Vector2 moveForward(int currentPosition)
    {
        queueSpots[currentPosition] = false;
        if (currentPosition > 0)
        {
            queueSpots[currentPosition - 1] = true;
            return queuePositions[currentPosition - 1];
        }
        else
            return new Vector2(0, 0);
    }

    public void DoorPressed()
    {
        PersonNavigation[] persons;
        persons = GetComponentsInChildren<PersonNavigation>();
        foreach (PersonNavigation person in persons)
        {
            person.DoorClicked();
        }
    }

    public int getQueueCount()
    {
        return queueCount;
    }

    public void addQueueCount()
    {
        queueCount++;
    }

    public void subtractQueueCount()
    {
        queueCount--;
    }
}
