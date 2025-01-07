using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Panel dentro del Canvas que contiene los elementos del menú
    public GameObject postProcessingVolume; 
    private bool isPaused = false;

    void Update()
    {
        if (!GameStateManager.Instance.GameStarted && !isPaused) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (pauseMenuPanel != null)
        {
            postProcessingVolume.SetActive(true); // Activa el blur
            pauseMenuPanel.SetActive(true); // Activa el panel
        }
        else
        {
            Debug.LogWarning("pauseMenuPanel no está asignado.");
        }

        GameStateManager.Instance.PauseGame();
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseMenuPanel != null)
        {
            postProcessingVolume.SetActive(false); // Desactiva el blur
            pauseMenuPanel.SetActive(false); // Desactiva el panel
        }

        GameStateManager.Instance.StartGame();
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Asegura que el tiempo esté normal
        SceneManager.LoadScene("0_MenuInicial"); // Carga el menú principal
    }
}
