using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseState : IGameState
{
    public void EnterState(GameManager2 gameManager)
    {
        Debug.Log("Entrando al estado de pausa.");
        UIManager2.Instance.ShowPauseMenu();  // Mostrar el men� de pausa
        Time.timeScale = 0;  // Pausar el juego
    }

    public void UpdateState(GameManager2 gameManager)
    {
        // Aqu� podemos manejar las acciones mientras el juego est� en pausa, por ejemplo:
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si presionamos Escape nuevamente, reanudamos el juego
            gameManager.SetState(new GameState());
        }
    }

    public void ExitState(GameManager2 gameManager)
    {
        Debug.Log("Saliendo del estado de pausa.");
        UIManager2.Instance.HidePauseMenu();  // Ocultar el men� de pausa
        Time.timeScale = 1;  // Reanudar el juego
    }
}
