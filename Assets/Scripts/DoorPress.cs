using UnityEngine;
using System.Collections;

public class DoorPress : MonoBehaviour {

    public GameObject gameHandler;

    // Use this for initialization
    void Start () {
        gameHandler = GameObject.FindGameObjectWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseDown()
    {
        gameHandler.GetComponent<selectedController>().giveSelectedTarget(this.gameObject);


         GameObject[] persons;


        persons = GameObject.FindGameObjectsWithTag("Person");

        //foreach (GameObject person in persons)
        //{
         //   person.GetComponent<PersonNavigation>().moveForward();
        //}

        for (int i = 0; i < persons.Length; i++)
        {
            persons[i].GetComponent<PersonNavigation>().moveForward();
        }
        
    }
}

