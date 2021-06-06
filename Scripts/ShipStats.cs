using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ShipStats 
{
    [Range(1,5)]
    public int maxHealth = 5;
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int maxLives = 3;
    [HideInInspector]
    public int currentLives = 3;

    public float shipSpeed;
    public float fireRate = 0.5f;
}
