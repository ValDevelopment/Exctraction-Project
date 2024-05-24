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
        flash.duration = 0.3f;
        flash.Flash();
        Destroy(gameObject, 0.3f);
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int damage = Random.Range(1, maxHp);
            CombatManager.Instance.TakeAction(damage, this);
        }
    }
}
