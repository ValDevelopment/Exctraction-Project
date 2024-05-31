using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveArrow : MonoBehaviour
{
    public KeyCode thisInput;
    public GameObject moveTo;
    public MapManager map;
    public DungeonTraversal d;
    public CombatManager c;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(thisInput))
        {
            Move();
        }
    }

    public void Move()
    {
        d.DeactivateArrows();
        map.EnterRoom(moveTo);
        c.OnTurnStart();
    }
}
