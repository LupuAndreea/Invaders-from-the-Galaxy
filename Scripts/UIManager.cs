using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public TextMeshProUGUI scoreText;
    private int score;
    
    public TextMeshProUGUI highscoreText;
    private int highscore;
    
    public TextMeshProUGUI coinsText;

    public TextMeshProUGUI waveText;
    private int wave;

    public Image[] lifeSprites;

    public Image healthBar;
    public Sprite[] healthBars;

    private Color32 active = new Color(1, 1, 1, 1);
    private Color32 inactive = new Color(1, 1, 1, 0.25f);

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void UpdateLives(int lives)
    {
        // iterate through every one of our image 
        foreach (Image i in instance.lifeSprites)
            i.color = instance.inactive;

        for (int i = 0; i < lives; i++)
        {
            instance.lifeSprites[i].color = instance.active;
        }
    }

    public static void UpdateHealthbar(int health)
    {
        instance.healthBar.sprite = instance.healthBars[health];
    }

    public  static void UpdateScore(int score)
    {
        instance.score += score;
        instance.scoreText.text = instance.score.ToString("000");
    }

    public static void UpdateHighScore()
    {
        // TO DO
    }

    public static void UpdateWaves()
    {
        instance.wave++;
        instance.waveText.text = instance.wave.ToString();
    }

    public static void UpdateCoins()
    {
        instance.coinsText.text = Inventory.currentCoins.ToString();
    }

    public static void ResetUI()
    {
        instance.score = 0;
        instance.wave = 0;
        instance.scoreText.text = instance.score.ToString("000");
        instance.waveText.text = instance.wave.ToString();

    }
}
