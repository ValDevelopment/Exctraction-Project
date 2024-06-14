using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonTraversal : MonoBehaviour
{
    public GameObject[] arrows;
    public MapManager map;

    public DungeonRoom currentRoom;
    private static DungeonTraversal _instance;
    public static DungeonTraversal Instance { get { return _instance; } }


    void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ActivateArrows(FindDirections());
        }
    }

    public void ActivateArrows(List<int> a)
    {
        DeactivateArrows();
        for(int i = 0; i< a.Count; i++)
        {
            arrows[a[i]].SetActive(true);
        }
    }
    public void DeactivateArrows()
    {
        foreach(GameObject obj in arrows)
        {
            obj.SetActive(false);
        }
    }

    public void AddLootBags()
    {
        GameObject[] loot = GameObject.FindGameObjectsWithTag("Loot_Enemy");
        foreach(GameObject obj in loot)
        {
            currentRoom.currentTresures.Add(obj);
        }
    }

    public List<int> FindDirections()
    {
        GameObject room = map.dungeonRooms[0];
        foreach(GameObject t in map.dungeonRooms)
        {
            if(t.GetComponent<MapIcon>().current)
            {
                room = t;
                break;
            }
        }
        MapIcon icon = room.GetComponent<MapIcon>();
        List<int> dir = new();
        foreach (GameObject o in icon.adjacentRooms)
        {
            if(o.transform.position.x > room.transform.position.x)
            {
                dir.Add(0);
                arrows[0].GetComponent<MoveArrow>().moveTo = o;
            }
            else if (o.transform.position.x < room.transform.position.x)
            {
                dir.Add(2);
                arrows[2].GetComponent<MoveArrow>().moveTo = o;
            }
            else if (o.transform.position.y > room.transform.position.y)
            {
                dir.Add(1);
                arrows[1].GetComponent<MoveArrow>().moveTo = o;
            }
            else if (o.transform.position.y < room.transform.position.y)
            {
                dir.Add(3);
                arrows[3].GetComponent<MoveArrow>().moveTo = o;
            }
        }
        return dir;
    }
}
