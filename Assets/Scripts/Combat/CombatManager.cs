using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public BasicAttack basicAttack;
    public int actionPoints;

    public int currentActionPointsNeeded;

    private static CombatManager _instance;
    public static CombatManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }


    public void TakeAction(int damage, EnemyHP enemy)
    {
        if (actionPoints >= currentActionPointsNeeded)
        {

            if (damage > 0)
                enemy.TakeDamage(damage);

            actionPoints -= currentActionPointsNeeded;
        }
    }
}
