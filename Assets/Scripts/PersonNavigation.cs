using UnityEngine;
using System.Collections;

public class PersonNavigation : MonoBehaviour {

    public enum personStates { moveToQueue, queue, moveToRoom, inRoom, leaving}
    public bool selected = false;
    public personStates state = personStates.moveToQueue;
    public Vector3 positionInfo;
    public Vector2 targetPosition;
    public Vector2 speed = new Vector2((float)2, (float)2);
    public Vector2 direction = new Vector2(0, 0);
    public int positionInQueue;
    public GameObject queue;
    public GameObject targetRoom;
    public GameObject gameHandler;
    public float toiletTime = 2;
    

	// Use this for initialization
	void Start () {
        state = personStates.moveToQueue;

        queue = GameObject.FindGameObjectWithTag("Queue");
        gameHandler = GameObject.FindGameObjectWithTag("GameController");
        
        positionInfo = queue.GetComponent<queueController>().getNextQueuePosition();

        targetPosition.x = positionInfo.x;
        targetPosition.y = positionInfo.y;
        positionInQueue = (int)positionInfo.z;

        if (positionInQueue == 0)
        {
            gameHandler.GetComponent<selectedController>().updateSelected(this.gameObject);
            selected = true;
        }        
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
                moveToRoomUpdate();
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
        //selected = true;
        //gameHandler.GetComponent<selectedController>().updateSelected(this.gameObject);
        //GetComponent<SpriteRenderer>().color = Color.red;
    }
    

    void getDirection(Vector2 start, Vector2 end)
    {
        direction.x = end.x - start.x;
        direction.y = end.y - start.y;        
    }

    public void chooseRoom(GameObject room)
    {
        targetRoom = room;
        targetPosition = room.transform.position;
        state = personStates.moveToRoom;
    }

    public void DoorClicked()
    {
        if (selected == false)
        {
            targetPosition = queue.GetComponent<queueController>().moveForward(positionInQueue);
            positionInQueue -= 1;
            state = personStates.moveToQueue;
        }
        else
        {
            queue.GetComponent<queueController>().moveForward(positionInQueue);
            selected = false;
            gameHandler.GetComponent<selectedController>().removeSelected();
        }

        if (positionInQueue == 0)
        {
            gameHandler.GetComponent<selectedController>().updateSelected(this.gameObject);
            selected = true;
        }

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

        if (transform.position.y <= targetPosition.y+0.25)
        {
            state = personStates.queue;
        }    
    }

    void queueUpdate()
    { }

    void moveToRoomUpdate()
    {        
        getDirection(transform.position, targetPosition);

        Vector3 movement = new Vector3(
       speed.x * direction.x,
       speed.y * direction.y,
       0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (transform.position.y <= targetPosition.y+0.25)
        {
            state = personStates.inRoom;
        }
    }


    void inRoomUpdate()
    {
        //toiletTime -= Time.deltaTime;

        //if (toiletTime < 0)
        //{
        //    state = personStates.leaving;
        //    targetPosition = new Vector2(0, -10);
        //}
        if (this.tag == "Male")
        {
            if (targetRoom.tag == "Male Door")
            {
                queue.GetComponent<queueController>().subtractQueueCount();
                GameObject.FindGameObjectWithTag("UI").GetComponent<GameConditions>().incrementScore();
                Destroy(this.gameObject);
            }
            else if (targetRoom.tag == "Female Door")
            {
                Application.LoadLevel("Game Over");
               // GUI.Box(new Rect(0, 0, Screen.width / 2, Screen.height / 2), "This is the text to be displayed");
            }
        }
        if (this.tag == "Female")
        {
            if (targetRoom.tag == "Female Door")
            {
                queue.GetComponent<queueController>().subtractQueueCount();
                GameObject.FindGameObjectWithTag("UI").GetComponent<GameConditions>().incrementScore();
                Destroy(this.gameObject);
            }
            else if (targetRoom.tag == "Male Door")
            {
                Application.LoadLevel("Game Over");
                // GUI.Box(new Rect(0, 0, Screen.width / 2, Screen.height / 2), "This is the text to be displayed");
            }
        }
    }  

    void leaveUpdate()
    {
        getDirection(transform.position, targetPosition);

        Vector3 movement = new Vector3(
       speed.x * direction.x,
       speed.y * direction.y,
       0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (transform.position.y <= targetPosition.y +0.5)
        {
            Destroy(this.gameObject);
        }
    }
}
