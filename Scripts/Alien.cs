using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    // The movement of the Alien is controlled by the AlienMaster Script
    public int scoreValue;
    public GameObject explosion;

    public GameObject coinPrefab;           // the most frequent
    public GameObject healthPrefab;         // the second most frequent
    public GameObject lifePrefab;           // the last 

    private const int COIN_CHANCE = 80;
    private const int HEALTH_CHANCE = 40;
    private const int LIFE_CHANCE = 10;

    public void Kill()
    {
        UIManager.UpdateScore(scoreValue);

        AlienMaster.allAliens.Remove(gameObject);
        
        int ran = Random.Range(0, 100);
        if (ran <= LIFE_CHANCE)
            Instantiate(lifePrefab, transform.position, Quaternion.identity);
        else if (ran <= HEALTH_CHANCE)
            Instantiate(healthPrefab, transform.position, Quaternion.identity);
        else if(ran <= COIN_CHANCE)
            Instantiate(coinPrefab, transform.position, Quaternion.identity);

        Instantiate(explosion, transform.position, Quaternion.identity);

        if (AlienMaster.allAliens.Count == 0)
        {
            GameManager.SpawnNewWave();
        }
        Destroy(gameObject);
    }
}
