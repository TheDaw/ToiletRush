using UnityEngine;
using System.Collections;

public class PersonNavigation : MonoBehaviour {

    public enum personStates { moveToQueue, queue, moveToRoom, inRoom, leaving}
    public bool selected = false;
    public personStates state = personStates.moveToQueue;
    public Vector2 targetPosition;
    public Vector2 speed = new Vector2((float)0.5, (float)0.5);
    public Vector2 direction = new Vector2(0, 0);
    public GameObject queue;
    

	// Use this for initialization
	void Start () {
        queue = GameObject.FindGameObjectWithTag("Queue");
        Vector2 startPosition = this.transform.position;
        targetPosition = queue.GetComponent<queueController>().getNextQueuePosition();        
    }
	
	// Update is called once per frame
	void Update () {

        switch (state)
        {
            case personStates.moveToQueue:
                moveToQueueUpdate();
                break;
            case personStates.queue:
                queueUpdate();
                break;
            case personStates.moveToRoom:
                //
                break;
            case personStates.inRoom:
                inRoomUpdate();
                break;
            case personStates.leaving:
                leaveUpdate();
                break;
        }            
	
	}

    void OnMouseDown()
    {
        selected = true;
    }
    

    void getDirection(Vector2 start, Vector2 end)
    {
        direction.x = end.x - start.x;
        direction.y = end.y - start.y;        
    }

    void moveToQueueUpdate()
    {
        getDirection(transform.position, targetPosition);

        Vector3 movement = new Vector3(
       speed.x * direction.x,
       speed.y * direction.y,
       0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (transform.position.y <= targetPosition.y)
        {
            state = personStates.queue;
        }    
    }

    void queueUpdate()
    { }

    void selectedUpdate()
    { }

    void inRoomUpdate()
    {

    }

    void leaveUpdate()
    {

    }
}
