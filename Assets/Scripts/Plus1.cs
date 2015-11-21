using UnityEngine;
using System.Collections;

public class Plus1 : MonoBehaviour {
    double life = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(0, (float)0.1));

        life -= Time.deltaTime;

        if (life < 0)
            Destroy(this.gameObject);
	}
}
