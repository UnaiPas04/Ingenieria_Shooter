using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStateManager : MonoBehaviour
{
    private IUIState currentState;

    public void SetState(IUIState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = newState;
        currentState.EnterState(this);
    }
    private void Start()
    {
        SetState(new MainMenuState()); // Estado inicial
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("1_Partida"); 
    }

    // Métodos para manejar transiciones específicas
    public void GoToMainMenu() => SetState(new MainMenuState());
    public void GoToPauseMenu() => SetState(new PauseMenuState());
    public void GoToCredits() => SetState(new CreditsState());
    public void GoToExit() => SetState(new ExitsState());
}