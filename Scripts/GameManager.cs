using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] allAlienSet;
    private GameObject currentSet;
    private Vector2 spawnPosition = new Vector2(0, 7.45f);

    private static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // we want to have a method that can be called from anywer in the project
    public static void SpawnNewWave()
    {
        instance.StartCoroutine(instance.SpawnWave());
    }

    public static void CancelGame()
    {
        // make shour that the current block of aliens is destroied
        instance.StopAllCoroutines();

        AlienMaster.allAliens.Clear();

        
        if (instance.currentSet != null)
        {
            Destroy(instance.currentSet);
        }
        UIManager.ResetUI();
    }
    private IEnumerator SpawnWave()
    {
        AlienMaster.allAliens.Clear();

        if (currentSet != null)
        {
            Destroy(currentSet);
        }
        // we always need a yield statement inside of a core routine
        yield return new WaitForSeconds(3);

        // Spawn a new set of aliens
        currentSet = Instantiate(allAlienSet[Random.Range(0, allAlienSet.Length)], spawnPosition, Quaternion.identity);
        UIManager.UpdateWaves();
    }
}
