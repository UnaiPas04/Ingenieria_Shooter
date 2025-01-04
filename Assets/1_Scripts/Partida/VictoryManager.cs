using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour, IHealthObserver
{
    public GameObject victoryScreen;
    private int enemiesAlive;

    void Start()
    {
        victoryScreen.SetActive(false);
        enemiesAlive = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        Debug.Log(enemiesAlive);
    }

    public void OnHealthChange(int currentHealth, int maxHealth)
    {
        if(currentHealth <= 0)
        {
            enemiesAlive--;
            CheckVictory();
        }
    }

    public void OnPlayerDeath() { }

    public void CheckVictory()
    {
        if (enemiesAlive <= 0)
        {
            victoryScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
