using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour, IHealthObserver
{
    public GameObject gameOverScreen;
    public PlayerHealth playerHealth;

    public void OnHealthChange(int currentHealth, int maxDeath)
    {
        return;
    }

    public void OnDeath()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Respawn()
    {
        playerHealth.ResetHealth();
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
