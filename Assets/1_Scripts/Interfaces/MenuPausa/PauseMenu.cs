using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Panel dentro del Canvas que contiene los elementos del menú
    public GameObject postProcessingVolume; 
    private bool isPaused = false;

    void Update()
    {
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

        Time.timeScale = 0f; // Congela el juego
        isPaused = true;

        Cursor.lockState = CursorLockMode.None; // Libera el cursor
        Cursor.visible = true; // Hace visible el cursor
    }

    public void ResumeGame()
    {
        if (pauseMenuPanel != null)
        {
            postProcessingVolume.SetActive(false); // Desactiva el blur
            pauseMenuPanel.SetActive(false); // Desactiva el panel
        }

        Time.timeScale = 1f; // Reanuda el juego
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
        Cursor.visible = false; // Oculta el cursor
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Asegura que el tiempo esté normal
        SceneManager.LoadScene("0_MenuInicial"); // Carga el menú principal
    }
}
