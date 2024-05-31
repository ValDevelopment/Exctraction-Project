using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoom : MonoBehaviour
{
    public List<GameObject> enemies = new();
    public List<GameObject> treasures = new();
    public List<GameObject> resources = new();

    public DungeonTraversal d;
    public BasicAttack basicAttack;



    public Transform nonenemyParent;

    public List<GameObject> currentTresures = new();
    public void StartThisEncounter()
    {
        basicAttack.attackMode = false;
        Debug.Log("Start");
        if(enemies.Count == 0)
        {
            Debug.Log("No enemies");
            d.ActivateArrows(d.FindDirections());
            SpawnTreasures();
            SpawnResources();
        } 
        else
        {
            SpawnEnemies();
        }
    }
    int GetChestRarity()
    {
        int rarity = 0;
        float chance = Random.Range(0.0f, 1.0f);
        if (chance < 0.65f)
        {
            rarity = 0;
        }
        else if (chance >= 0.65f && chance < 0.80f)
        {
            rarity = 1;
        }
        else if (chance >= 0.80f && chance < 0.90f)
        {
            rarity = 2;
        }
        else if (chance >= 0.90f && chance < 0.97f)
        {
            rarity = 3;
        }
        else if (chance >= 0.97f && chance <= 1.0f)
        {
            rarity = 4;
        }
        return rarity;
    }

    public void SpawnTreasures()
    {
        if (currentTresures.Count == 0)
        {
            GameObject[] positions = GameObject.FindGameObjectsWithTag("EnemyPosition");
            for (int i = 0; i < treasures.Count; i++)
            {
                GameObject obj = Instantiate(treasures[0], positions[i].transform.position, Quaternion.identity, nonenemyParent);

                ChestBehaviour thisChest = treasures[0].GetComponent<ChestBehaviour>();
                int rarity = GetChestRarity();
                thisChest.chestRarity = rarity;
                treasures[0].GetComponent<SpriteRenderer>().sprite = ItemsDataHolder.Instance.chestSprites[rarity];
                currentTresures.Add(obj);
            }
        }
        else
        {
            foreach(GameObject obj in currentTresures)
            {
                obj.SetActive(true);
            }
        }
    }
    
    public void SpawnEnemies()
    {
        GameObject[] positions = GameObject.FindGameObjectsWithTag("EnemyPosition");
        for(int i = 0; i < 3; i++)
        {
            Instantiate(enemies[0], positions[i].transform.position, Quaternion.identity);
        }
        enemies.Clear();
    }

    public void SpawnResources()
    {

    }
}
