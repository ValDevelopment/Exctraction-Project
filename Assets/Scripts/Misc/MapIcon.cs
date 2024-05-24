using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIcon : MonoBehaviour
{
    public List<GameObject> adjacentRooms;
    public List<int> directions;
    static int allowedTimes = 5;
    public static int times = 0;
    public bool current;
    // Start is called before the first frame update
    void Awake()
    {
        //ActivateAdjacent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateAdjacent()
    {
        if(times < allowedTimes)
        {
            foreach(GameObject obj in adjacentRooms)
            {
                obj.SetActive(true);
            }
            times++;
        }
    }

}
