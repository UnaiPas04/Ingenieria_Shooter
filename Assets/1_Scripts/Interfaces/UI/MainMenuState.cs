using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : IUIState
{
    public void EnterState(UIStateManager uiManager)
    {
        Debug.Log("Entrando al Men� Principal");
        UIManager.Instance.ShowMainMenu();
    }

    public void UpdateState(UIStateManager uiManager)
    {
        // Detectar si el jugador pulsa "Start"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            uiManager.GoToPauseMenu(); // Ejemplo: pasar al men� de pausa
        }
    }

    public void ExitState(UIStateManager uiManager)
    {
        Debug.Log("Saliendo del Men� Principal");
        UIManager.Instance.HideMainMenu();
    }
}
