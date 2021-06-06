using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject mothershipPrefab;

    private Vector3 horizontalMoveDistance = new Vector3(0.05f, 0, 0);
    private Vector3 verticalMoveDistance = new Vector3(0, 0.20f, 0);

    private Vector3 mothershipSpawnPosition = new Vector3(11f, 4f, 0);

    private const float MAX_LEFT = -3.87f;
    private const float MAX_RIGHT = 3.87f;
    private const float MAX_MOVE_SPEED = 0.02f;

    // I don't want my mothership to spown in every 60s
    // Mothership will spawn at a random time 
    private const float MOTHERSHIP_MIN = 15f;
    private const float MOTHERSHIP_MAX = 60f;

    private const float START_Y = 0.6f;

    // moveTime to calculate the action speed of muvement
    private const float moveTime = 0.005f;
    private float moveTimer = 0.01f;

    private const float shootTime = 3f;
    private float shootTimer = 3f;

    private const float mothershipTime = 60f;
    private float mothershipTimer = 1f;


    private bool movingRight;

    public static List<GameObject> allAliens = new List<GameObject>();

    private bool entering = true;


    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Alien"))
            allAliens.Add(go);
    }

    // Update is called once per frame
    void Update()
    {
        if (entering)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 10);
            if (transform.position.y <= START_Y)
            {
                entering = false;
            }
        }
        else
        {
            if (moveTimer <= 0)
            {
                MoveEnemies();
            }
            moveTimer -= Time.deltaTime;

            if (shootTimer <= 0)
            {
                Shoot();

            }
            shootTimer -= Time.deltaTime;

            if (mothershipTimer <= 0)
            {
                SpawnMothership();
            }
            mothershipTimer -= Time.deltaTime;
        }
       
    }

    private void MoveEnemies()
    {
        //chek if is at last one alien in the level 
        if (allAliens.Count > 0)
        {
            // how many aliens have hit one of the bondraies
            int hitMax = 0;

            for (int i = 0; i < allAliens.Count; i++)
            {
                if (movingRight)
                {
                    allAliens[i].transform.position += horizontalMoveDistance;
                }
                else
                {
                    allAliens[i].transform.position -= horizontalMoveDistance;
                }

                if (allAliens[i].transform.position.x > MAX_RIGHT || allAliens[i].transform.position.x < MAX_LEFT)
                {
                    hitMax++;
                }
            }

            if (hitMax > 0)
            {
                for (int i = 0; i < allAliens.Count; i++)
                {
                    allAliens[i].transform.position -= verticalMoveDistance;
                }
                movingRight = !movingRight;
            }
            moveTimer = GetMOveSpeed();
            
        }
    }

    private void Shoot()
    {
        Vector2 shootPosition = allAliens[Random.Range(0, allAliens.Count)].transform.position;

        Instantiate(bulletPrefab, shootPosition, Quaternion.identity);
        shootTimer = shootTime;
    }

    private void SpawnMothership()
    {
        Instantiate(mothershipPrefab, mothershipSpawnPosition, Quaternion.identity);
        mothershipTimer = Random.Range(MOTHERSHIP_MIN, MOTHERSHIP_MAX);
    }
    // speed calculation methos
    private float GetMOveSpeed()
    {
        float speed = allAliens.Count * moveTime;
        if (speed < MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        else
        {
            return speed;
        }
        
    }
}
