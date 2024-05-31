using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionManager : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 pos;
    public int damage;
    // Start is called before the first frame update
    void Awake()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<pos.y)
        {
            transform.position = pos;
            ResetGravityScale();
            PlayerHP.Instance.TakeDamage(damage);
        }
    }

    public void Attack()
    {
        rb.velocity = Vector2.up * 3.33f;
        Invoke("MoveDown", 0.25f);
    }

    void MoveDown()
    {
        rb.velocity = Vector2.zero;
        rb.gravityScale = 1;
    }

    void ResetGravityScale()
    {
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
    }
}
