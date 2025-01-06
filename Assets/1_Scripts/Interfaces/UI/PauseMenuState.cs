using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuState : IUIState
{
    public void EnterState(UIStateManager uiManager)
    {
        Debug.Log("Entrando al Menú de Pausa");
        UIManager.Instance.ShowPauseMenu();
        Time.timeScale = 0; // Pausar el juego
    }

    public void UpdateState(UIStateManager uiManager)
    {
        // Detectar si el jugador reanuda el juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1; // Reanudar el juego
            uiManager.GoToMainMenu(); // Volver al menú principal
        }
    }

    public void ExitState(UIStateManager uiManager)
    {
        Debug.Log("Saliendo del Menú de Pausa");
        UIManager.Instance.HidePauseMenu();
        Time.timeScale = 1; // Asegurarse de reanudar el juego
    }
}
