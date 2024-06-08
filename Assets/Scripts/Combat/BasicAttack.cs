using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public bool attackMode;
    public GameObject activeIndic;
    public GameObject dark;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            OnButtonPress();
        }
    }

    public void OnButtonPress()
    {
        if (!dark.activeSelf)
        {
            if (attackMode)
            {
                ExitAttackMode();
            }
            else
            {
                EnterAttackMode();
            }
        }
    }

    void EnterAttackMode()
    {
        activeIndic.SetActive(true);
        CombatManager.Instance.currentActionPointsNeeded = 1;
        attackMode = true;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        /*
        foreach(GameObject obj in enemies)
        {
            BoxCollider2D col = obj.GetComponent<BoxCollider2D>();
            col.enabled = true;
        }
        */
    }

    public void ExitAttackMode()
    {
        activeIndic.SetActive(false);
        CombatManager.Instance.currentActionPointsNeeded = 0;
        attackMode = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        /*
        foreach (GameObject obj in enemies)
        {
            BoxCollider2D col = obj.GetComponent<BoxCollider2D>();
            col.enabled = false;
        }
        */
    }
}
