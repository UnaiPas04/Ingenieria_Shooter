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
    
    }

    public void ExitState(UIStateManager uiManager)
    {
        Debug.Log("Saliendo del Men� Principal");
        UIManager.Instance.HideMainMenu();
    }
}
