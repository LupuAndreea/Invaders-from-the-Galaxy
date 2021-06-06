using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeniuManager : MonoBehaviour
{
    //responsable for oppening up the coresponding game meniu
    public GameObject mainMeniu;
    public GameObject gameOverMeniu;
    public GameObject shopMeniu;
    public GameObject inGameMeniu;
    public GameObject pauseMeniu;

    public static MeniuManager instamce;

    private void Awake()
    {
        if (instamce == null)
        {
            instamce = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ReturnToMainMeniu();
    }

    public void OpenMainMeniu()
    {
        instamce.mainMeniu.SetActive(true);
        instamce.inGameMeniu.SetActive(false);
    }
    
    public static void OpenGameOver()
    {
        instamce.gameOverMeniu.SetActive(true);
        instamce.inGameMeniu.SetActive(false);
    }
    
    public void OpenShop()
    {
        instamce.mainMeniu.SetActive(false);
        instamce.shopMeniu.SetActive(true);

    }
    public void CloseShop()
    {
        instamce.mainMeniu.SetActive(true);
        instamce.shopMeniu.SetActive(false);
    }

    public void OpenInGame()
    {
        Time.timeScale = 1;

        instamce.mainMeniu.SetActive(false);
        instamce.pauseMeniu.SetActive(false);
        instamce.shopMeniu.SetActive(false);
        instamce.gameOverMeniu.SetActive(false);

        GameManager.SpawnNewWave();

    }

    public void OpenPause()
    {
        Time.timeScale = 0;
        instamce.inGameMeniu.SetActive(false);
        instamce.pauseMeniu.SetActive(true);

    }

    public void ClosePause()
    {
        Time.timeScale = 1;
        instamce.inGameMeniu.SetActive(true);
        instamce.pauseMeniu.SetActive(false);
    }

    public void ReturnToMainMeniu()
    {
        Time.timeScale = 1;

        instamce.gameOverMeniu.SetActive(false);
        instamce.shopMeniu.SetActive(false);
        instamce.pauseMeniu.SetActive(false);
        instamce.inGameMeniu.SetActive(false);

        instamce.mainMeniu.SetActive(true);

        GameManager.CancelGame();

    }

    public static void CloseWindow(GameObject go)
    {
        go.SetActive(false);
    }
   
}
