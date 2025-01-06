using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsState : IUIState
{
    public void EnterState(UIStateManager uiManager)
    {
        Debug.Log("Entrando a los Cr�ditos");
        UIManager.Instance.ShowCredits();
    }

    public void UpdateState(UIStateManager uiManager)
    {
        // Detectar si el jugador pulsa para volver al men� principal
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiManager.GoToMainMenu();
        }
    }

    public void ExitState(UIStateManager uiManager)
    {
        Debug.Log("Saliendo de los Cr�ditos");
        UIManager.Instance.HideCredits();
    }
}