using UnityEngine;
using System.Collections;

public class MenuPersonSpawner : MonoBehaviour
{

    public int totalActive = 0;
    public float spawner = 0;
    public GameObject Boy;
    public GameObject Girl;
    Random ranGen = new Random();
    GameObject childControl;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        spawner = spawner + Time.deltaTime;

        if (spawner > 1.5)
        {
        spawnPerson();
        spawner = 0;
        totalActive++;
        }

    }

    void spawnPerson()
    {
        switch (Random.Range(0, 2))
        {
            case 0:
                childControl = Instantiate(Boy, new Vector3(0, 8, 0), Quaternion.identity) as GameObject;
                break;
            case 1:
                childControl = Instantiate(Girl, new Vector3(0, 8, 0), Quaternion.identity) as GameObject;
                break;
        }
    }

}
