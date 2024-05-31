using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnsManager : MonoBehaviour
{
    public CombatManager combatManager;
    public GameObject[] toDisable;
    public GameObject[] toEnable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndPlayerTurn()
    {
        combatManager.basicAttack.ExitAttackMode();
        DisableButtons();
        StartEnemyTurn();
    }

    public void StartPlayerTurn()
    {
        EnableButtons();
        combatManager.OnTurnStart();
    }

    void DisableButtons()
    {
        foreach(GameObject obj in toDisable)
        {
            obj.GetComponent<Button>().enabled = false;
        }

        foreach(GameObject obj in toEnable)
        {
            obj.SetActive(true);
        }
    }

    void EnableButtons()
    {
        foreach (GameObject obj in toDisable)
        {
            obj.GetComponent<Button>().enabled = true;
        }

        foreach (GameObject obj in toEnable)
        {
            obj.SetActive(false);
        }
    }

    public void StartEnemyTurn()
    {
        GameObject[] enemeis = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemeis.Length; i++)
        {
            EnemyActionManager enemy = enemeis[i].GetComponent<EnemyActionManager>();
            enemy.Invoke("Attack", i * 0.8f);
        }
        Invoke("StartPlayerTurn", enemeis.Length*1f);
    }
}
