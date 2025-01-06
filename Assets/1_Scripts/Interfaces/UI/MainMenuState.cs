using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : IUIState
{
    public void EnterState(UIStateManager uiManager)
    {
        Debug.Log("Entrando al Menú Principal");
        UIManager.Instance.ShowMainMenu();
    }

    public void UpdateState(UIStateManager uiManager)
    {
        // Detectar si el jugador pulsa "Start"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            uiManager.GoToPauseMenu(); // Ejemplo: pasar al menú de pausa
        }
    }

    public void ExitState(UIStateManager uiManager)
    {
        Debug.Log("Saliendo del Menú Principal");
        UIManager.Instance.HideMainMenu();
    }
}
