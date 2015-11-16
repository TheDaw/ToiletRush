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
    }
}
