using UnityEngine;
using System.Collections;

public class PersonSpawner : MonoBehaviour {

    public int totalActive = 0;
    public float spawner = 0;
    public GameObject Man;
    public GameObject Woman;
    public GameObject Boy;
    public GameObject Girl;
    Random ranGen = new Random();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        spawner = spawner + Time.deltaTime;

        if (spawner > 10)
        {
            spawnPerson();
            spawner = 0;
            totalActive++;
        }

        
	}

    void spawnPerson()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                Instantiate(Man, new Vector3(0, 50, 0), Quaternion.identity);
                break;
            case 1:
                Instantiate(Woman, new Vector3(0, 50, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(Boy, new Vector3(0, 50, 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(Girl, new Vector3(0, 50, 0), Quaternion.identity);
                break;
        }
    }
    
}
