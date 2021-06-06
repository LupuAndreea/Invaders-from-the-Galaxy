using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // remember the state of damage
    public Sprite[] states;
    private int health;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        // 4 differrent danage states
        health = 4;
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            // destroy the enemy bullet
            Destroy(collision.gameObject);
            health--;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                sr.sprite = states[health - 1];
            }
        }

        if (collision.gameObject.CompareTag("FrendlyBullet"))
        {
            Destroy(collision.gameObject);
        }
    }

}
