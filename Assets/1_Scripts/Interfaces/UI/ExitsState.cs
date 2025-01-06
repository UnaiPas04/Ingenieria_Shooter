using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitsState : IUIState
{

    public void EnterState(UIStateManager uiManager)
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void UpdateState(UIStateManager uiManager)
    {
        
    }
    
    public void ExitState(UIStateManager uiManager)
    {
      
    }

  
   
}
