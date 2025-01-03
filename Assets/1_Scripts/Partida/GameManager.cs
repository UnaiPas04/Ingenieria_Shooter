using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Healthbar healthbar;
    public GameOverScreen gameOverScreen;

    void Start()
    {
        playerHealth.AddObserver(healthbar);
        playerHealth.AddObserver(gameOverScreen);
    }
}
