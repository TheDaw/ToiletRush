using UnityEngine;
using System.Collections;

public class selectedController : MonoBehaviour {

    public GameObject selectedPerson;
    GameObject selectedRoom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void updateSelected(GameObject selected)
    {
        selectedPerson = selected;
    }

    public void giveSelectedTarget(GameObject room)
    {
        selectedPerson.GetComponent<PersonNavigation>().chooseRoom(room);
    }
}
