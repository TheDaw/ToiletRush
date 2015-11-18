using UnityEngine;
using System.Collections;

public class PersonSpawner : MonoBehaviour {

    public int totalActive = 0;
    public float spawner = 0;
    public GameObject Man;
    public GameObject Woman;
    Random ranGen = new Random();
    GameObject queue;
    GameObject childControl;

	// Use this for initialization
	void Start () {
        queue = GameObject.FindGameObjectWithTag("Queue");
    }
	
	// Update is called once per frame
	void Update () {
        if (queue.GetComponent<queueController>().getQueueCount() < 50)
        {

            spawner = spawner + Time.deltaTime;

            if (spawner > 3)
            {
                spawnPerson();
                spawner = 0;
                totalActive++;
            }
        }

        
	}

    void spawnPerson()
    {
        switch (Random.Range(0, 2))
        {
            case 0:
                childControl = Instantiate(Man, new Vector3(0, 10, 0), Quaternion.identity) as GameObject;
                childControl.transform.parent = queue.transform;
                queue.GetComponent<queueController>().addQueueCount();
                break;
            case 1:
                childControl = Instantiate(Woman, new Vector3(0, 10, 0), Quaternion.identity) as GameObject;
                childControl.transform.parent = queue.transform;
                queue.GetComponent<queueController>().addQueueCount();
                break;
        }
    }
    
}
