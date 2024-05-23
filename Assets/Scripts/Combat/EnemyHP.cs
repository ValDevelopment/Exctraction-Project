using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Slider hpSlider;
    public int maxHp;
    int currentHp;

    public EnemyStatus thisEnemyStatus;

    public SimpleFlash flash;

    public Text damageText;
    // Start is called before the first frame update
    void Start()
    {
        hpSlider.minValue = 0;
        hpSlider.maxValue = maxHp;
        currentHp = maxHp;
        hpSlider.value = currentHp;
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
        Invoke("Erase", 0.5f);
    }

    void Erase()
    {
        damageText.text = "";
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int damage = Random.Range(1, 123);
            CombatManager.Instance.TakeAction(damage, this);
        }
    }
}
