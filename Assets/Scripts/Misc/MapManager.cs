using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public GameObject[] dungeonRooms;
    private List<int> activatedRooms = new();
    public GameObject connectingPrefab;
    public GameObject playerLocation;

    public GameObject testEnemy;
    public GameObject testChest;

    public Transform treasures;
    void Start()
    {
        // Ensure there are 25 GameObjects assigned
        if (dungeonRooms.Length != 25)
        {
            Debug.LogError("There are not exactly 25 GameObjects assigned to dungeonRooms.");
            return;
        }

        ActivateDungeon();
    }

    void ActivateDungeon()
    {
        int roomsToActivate = Random.Range(10, 13); // Random number between 10 and 12 (inclusive)
        int startRoom = Random.Range(0, dungeonRooms.Length); // Pick a random start room
        DFS(startRoom, roomsToActivate);
        AssignEncounters();
        // Instantiate connections after all rooms have been activated
        InstantiateConnections();
        EnterRoom(dungeonRooms[startRoom]);
    }

    public void AssignEncounters()
    {
        foreach (int roomIndex in activatedRooms)
        {
            GameObject room = dungeonRooms[roomIndex];
            DungeonRoom dungRoom = room.GetComponent<DungeonRoom>();
            dungRoom.enemies.Add(testEnemy);
            int treasures = Random.Range(0, 3);
            for (int i = 0; i < treasures; i++)
            {
                dungRoom.treasures.Add(testChest);
            }
        }
    }
    public void EnterRoom(GameObject room)
    {
        foreach(Transform t in treasures)
        {
            t.gameObject.SetActive(false);
            ChestBehaviour thisChest = t.GetComponent<ChestBehaviour>();
            thisChest.CloseChest();
        }
        foreach(GameObject obj in dungeonRooms)
        {
            obj.GetComponent<MapIcon>().current = false;
            if(obj.transform.childCount > 1)
                Destroy(obj.transform.GetChild(1).gameObject);
        }
        Instantiate(playerLocation, room.transform);
        room.GetComponent<MapIcon>().current = true;
        room.GetComponent<DungeonRoom>().StartThisEncounter();
        DungeonTraversal.Instance.currentRoom = room.GetComponent<DungeonRoom>();
    }

    void DFS(int currentRoom, int roomsToActivate)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(currentRoom);

        while (stack.Count > 0 && activatedRooms.Count < roomsToActivate)
        {
            int room = stack.Pop();

            if (!activatedRooms.Contains(room))
            {
                activatedRooms.Add(room);
                dungeonRooms[room].SetActive(true);

                List<int> neighbors = GetConnectedRooms(room);
                Shuffle(neighbors); // Shuffle the neighbors before pushing them onto the stack

                foreach (int neighbor in neighbors)
                {
                    if (!activatedRooms.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                    }
                }
            }
        }

        if (activatedRooms.Count < roomsToActivate)
        {
            Debug.LogWarning("Could not activate the desired number of rooms while maintaining connectivity.");
        }
    }

    List<int> GetConnectedRooms(int roomIndex)
    {
        // Assuming rooms are arranged in a 5x5 grid for simplicity
        List<int> connectedRooms = new List<int>();
        int gridSize = 5;

        // Calculate row and column of the current room
        int row = roomIndex / gridSize;
        int col = roomIndex % gridSize;

        // Check and add adjacent rooms
        if (row > 0) connectedRooms.Add(roomIndex - gridSize); // Up
        if (row < gridSize - 1) connectedRooms.Add(roomIndex + gridSize); // Down
        if (col > 0) connectedRooms.Add(roomIndex - 1); // Left
        if (col < gridSize - 1) connectedRooms.Add(roomIndex + 1); // Right

        return connectedRooms;
    }

    void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void InstantiateConnections()
    {
        foreach (int roomIndex in activatedRooms)
        {
            GameObject room = dungeonRooms[roomIndex];
            List<int> neighbors = GetConnectedRooms(roomIndex);
            foreach (int neighborIndex in neighbors)
            {
                if (activatedRooms.Contains(neighborIndex))
                {
                    GameObject neighborRoom = dungeonRooms[neighborIndex];
                    InstantiateConnectingPrefab(room, neighborRoom);
                }
            }
        }
    }

    void InstantiateConnectingPrefab(GameObject roomA, GameObject roomB)
    {
        // Calculate the position between the two rooms
        Vector3 positionA = roomA.transform.position;
        Vector3 positionB = roomB.transform.position;
        MapIcon iconA = roomA.GetComponent<MapIcon>();
        MapIcon iconB = roomB.GetComponent<MapIcon>();
        if (!iconA.adjacentRooms.Contains(roomB))
        {
            iconA.adjacentRooms.Add(roomB);
        }

        if (!iconB.adjacentRooms.Contains(roomA))
        {
            iconB.adjacentRooms.Add(roomA);
           
        }
        
        Vector3 connectingPosition = (positionA + positionB) / 2;

        // Instantiate the connecting prefab at the calculated position
        Instantiate(connectingPrefab, connectingPosition, Quaternion.identity, transform.GetChild(0));
    }
}
