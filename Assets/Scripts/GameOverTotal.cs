using UnityEngine;
using System.Collections;

public class GameOverTotal : MonoBehaviour {

    public GUIText scoreText;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        scoreText.text = "Final Score: " + PlayerPrefs.GetInt("Player Score");

    }
}
