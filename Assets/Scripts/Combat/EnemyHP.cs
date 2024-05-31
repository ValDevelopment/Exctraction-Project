using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Slider hpSlider;
    public Slider hpSliderWhite;
    public int maxHp;
    int currentHp;

    public EnemyStatus thisEnemyStatus;

    public SimpleFlash flash;

    public Text damageText;

    public SpriteRenderer thisSprite;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        hpSlider.minValue = 0;
        hpSlider.maxValue = maxHp;
        hpSlider.value = currentHp;
        hpSliderWhite.minValue = 0;
        hpSliderWhite.maxValue = maxHp;
        hpSliderWhite.value = currentHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        CancelInvoke("Erase");
        flash.Flash();
        damageText.text = damage + "";
        if(currentHp - damage > 0) { 
            currentHp -= damage;
        
        }
        else
        {
            currentHp = 0;
            Death();
            Invoke("CheckLastEnemy", 0.28f);
        }
        hpSlider.value = currentHp;
        Invoke("Erase", 0.5f);
    }

    void Erase()
    {
        damageText.text = "";
        hpSliderWhite.value = currentHp;
    }

    void Death()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        flash.duration = 0.3f;
        flash.Flash();
        Destroy(transform.parent.gameObject, 0.3f);
    }

    void CheckLastEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 1)
        {
            DungeonTraversal d = GameObject.Find("MoveArrows").GetComponent<DungeonTraversal>();
            d.ActivateArrows(d.FindDirections());
            DungeonTraversal.Instance.currentRoom.SpawnTreasures();
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && CombatManager.Instance.basicAttack.attackMode)
        {
            int damage = Random.Range(1, maxHp);
            CombatManager.Instance.TakeAction(damage, this);
        }
    }

    private void OnMouseEnter()
    {
        if (CombatManager.Instance.basicAttack.attackMode)
        {
            thisSprite.color = Color.grey;
        }
    }

    private void OnMouseExit()
    {
        if (CombatManager.Instance.basicAttack.attackMode)
        {
            thisSprite.color = Color.white;
        }
    }
}
