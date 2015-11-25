using UnityEngine;
using System.Collections;

public class ViewAchieve : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag("Google").GetComponent<GPGS>().ShowAchievementsUI();
    }
}
