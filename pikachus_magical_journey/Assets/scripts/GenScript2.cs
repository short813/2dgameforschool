using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenScript2 : MonoBehaviour
{
    public GameObject[] availableRooms;
    public List<GameObject> currentRooms;
    private float screenWidthInPoints;
    // generating cheese and pidgey
    public GameObject[] availableObjects;
    public List<GameObject> objects;

    public float objectsMinDistance = 5.0f;
    public float objectsMaxDistance = 10.0f;

    public float objectsMinY = -1.4f;
    public float objectsMaxY = 1.4f;

    // Use this for initialization
    void Start()
    {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoints = height * Camera.main.aspect;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        GenerateRoomIfRequired();
        GenerateObjectsIfRequired();
    }



    void AddObject(float lastObjectX)
    {
        // Gives random index for objects
        int randomIndex = Random.Range(0, availableObjects.Length);
        //  create an instance of an object
        GameObject obj = (GameObject)Instantiate(availableObjects[randomIndex]);
        //give the object a location
        float objectPositionX = lastObjectX + Random.Range(objectsMinDistance, objectsMaxDistance);
        float randomY = Random.Range(objectsMinY, objectsMaxY);
        obj.transform.position = new Vector3(objectPositionX, randomY, 0);

        //5 addes the object to the screen
        objects.Add(obj);
    }
    void GenerateObjectsIfRequired()
    {
        //1 Check things behind and ahead of character
        float playerX = transform.position.x;
        float removeObjectsX = playerX - screenWidthInPoints;
        float addObjectX = playerX + screenWidthInPoints;
        float farthestObjectX = 0;

        //2 Objects to remove 
        List<GameObject> objectsToRemove = new List<GameObject>();
        foreach (var obj in objects)
        {
            //3 position of the object
            float objX = obj.transform.position.x;

            //4 each object gets the fartheset object value
            farthestObjectX = Mathf.Max(farthestObjectX, objX);


            //5 marks objects to remove
            if (objX < removeObjectsX)
                objectsToRemove.Add(obj);
        }

        //6 removes the objects
        foreach (var obj in objectsToRemove)
        {
            if (gameObject != null)
            {
                objects.Remove(obj);
                Destroy(obj);
            }
        }

        //7 adds more objects
        if (farthestObjectX <= addObjectX)
        {
            AddObject(farthestObjectX);
        }
    }

    void AddRoom(float farthestRoomEndX)
    {
        //1
        int randomRoomIndex = Random.Range(0, availableRooms.Length);
        //2
        GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);
        //3
        float roomWidth = room.transform.FindChild("floor").localScale.x;
        //4
        float roomCenter = farthestRoomEndX + roomWidth * .5f;
        //5
        room.transform.position = new Vector3(roomCenter, 0, 0);
        //6
        currentRooms.Add(room);
    }
    void GenerateRoomIfRequired()
    {
        //1
        List<GameObject> roomsToRemove = new List<GameObject>();
        //2
        bool addRooms = true;
        //3
        float playerX = transform.position.x;
        //4
        float removeRoomX = playerX - screenWidthInPoints;
        //5
        float addRoomX = playerX + screenWidthInPoints;
        //6
        float farthestRoomEndX = 0;

        foreach (var room in currentRooms)
        {
            //7
            float roomWidth = room.transform.FindChild("floor").localScale.x;
            float roomStartX = room.transform.position.x - (roomWidth * 0.3f);
            float roomEndX = roomStartX + roomWidth;
            //8
            if (roomStartX > addRoomX)
                addRooms = false;
            //9
            if (roomEndX < removeRoomX)
                roomsToRemove.Add(room);
            //10
            farthestRoomEndX = Mathf.Max(farthestRoomEndX, roomEndX);
        }
        //11
        foreach (var room in roomsToRemove)
        {
            if (gameObject != null)
            {
                currentRooms.Remove(room);
                Destroy(room);
            }
        }
        //12
        if (addRooms)
            AddRoom(farthestRoomEndX);
    }

}
