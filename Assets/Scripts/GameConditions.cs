using UnityEngine;
using System.Collections;

public class GameConditions : MonoBehaviour {

    public GUIText scoreText;
    private int score;

    // Use this for initialization
    void Start () {
        score = 0;
       // lives = 3;	
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
    }    

    void onGUI()
    {
        //GUI.Label(new Rect(10, 10, 100, 20), "Score: " + score.ToString());
    }

    public void incrementScore()
    {
        score++;
    }
}
