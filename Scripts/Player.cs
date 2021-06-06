using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public ShipStats shipStats;

    private const float MAX_LEFT = -3f;
    private const float MAX_RIGHT = 3f;

    private bool isShooting;
    private Vector2 offScreenPosition = new Vector2(0, -20f);
    private Vector2 startPosition = new Vector2(0, -5f);


    void Start()
    {
        shipStats.currentHealth = shipStats.maxHealth;
        shipStats.currentLives = shipStats.maxLives;
        transform.position = startPosition;

        UIManager.UpdateHealthbar(shipStats.currentHealth);
        UIManager.UpdateLives(shipStats.currentLives);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > MAX_LEFT)
            transform.Translate(Vector2.left * Time.deltaTime * shipStats.shipSpeed);

        if (Input.GetKey(KeyCode.D) && transform.position.x < MAX_RIGHT)
            transform.Translate(Vector2.right * Time.deltaTime * shipStats.shipSpeed);

        if (Input.GetKey(KeyCode.Space) && !isShooting)
            StartCoroutine(Shoot());
    }

    public void AddHealth()
    {
        if(shipStats.currentHealth == shipStats.maxHealth)
        {
            // we can't give more health to the player 
            UIManager.UpdateScore(100);
        }
        else
        {
            shipStats.currentHealth++;
            UIManager.UpdateHealthbar(shipStats.currentHealth);
        }
    }

    public void AddLife()
    {
        if (shipStats.currentLives == shipStats.maxLives)
        {
            // we can't give more lives to the player 
            UIManager.UpdateScore(200);
        }
        else
        {
            shipStats.currentLives++;
            UIManager.UpdateLives(shipStats.currentLives);
        }
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(shipStats.fireRate);
        isShooting = false;
    }

    private void TakeDamage()
    {
        shipStats.currentHealth--;
        UIManager.UpdateHealthbar(shipStats.currentHealth);

        if(shipStats.currentHealth <= 0)
        {
            shipStats.currentLives--;
            UIManager.UpdateLives(shipStats.currentLives);
            if (shipStats.currentLives <= 0)
            {
                //GameOver
                Debug.Log("GAME OVER");
            }
            else
            {
                StartCoroutine(Respawn());
                Debug.Log("RESPAWNING");
            }
        }

    }

    private IEnumerator Respawn()
    {
        transform.position = offScreenPosition;

        yield return new WaitForSeconds(2);
        shipStats.currentHealth = shipStats.maxHealth;
        UIManager.UpdateHealthbar(shipStats.currentHealth);

        transform.position = startPosition;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("PLAYER HIT");
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
    
}
