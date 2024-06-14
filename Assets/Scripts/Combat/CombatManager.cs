using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public BasicAttack basicAttack;
    public int maxActionPoints;
    public int currentActionPoints;

    public int currentActionPointsNeeded;

    public GridLayoutGroup divisors;
    public Transform divisorsParent;
    public Slider actions;
    public DungeonTimeManager energyManager;

    readonly int[] spacings = new int[] { 97, 97, 74, 57 };

    private static CombatManager _instance;
    public static CombatManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
        currentActionPoints = maxActionPoints;
        actions.maxValue = maxActionPoints;
        actions.minValue = 0;
        actions.value = currentActionPoints;
        DisplayDivisors();
    }

    public void OnTurnStart()
    {
        currentActionPoints = maxActionPoints;
        actions.value = currentActionPoints;
    }

    void DisplayDivisors()
    {
        int divisorsAmount = maxActionPoints - 1;
        if(divisorsAmount > 0)
            divisors.spacing = new Vector2(spacings[divisorsAmount-1], 0);
        for(int i = 0; i < divisorsAmount; i++)
        {
            divisorsParent.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void TakeAction(int damage, EnemyHP enemy)
    {
        if (currentActionPoints >= currentActionPointsNeeded)
        {

            if (damage > 0)
                enemy.TakeDamage(damage);

            currentActionPoints -= currentActionPointsNeeded;
            actions.value = currentActionPoints;
            energyManager.ReduceEnergy(currentActionPointsNeeded);
        }
    }
}
