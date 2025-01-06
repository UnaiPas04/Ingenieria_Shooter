using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class GameState : IGameState
{
    public void EnterState(GameManager2 gameManager)
    {
        Debug.Log("Entrando al estado de juego.");
        Time.timeScale = 1;  // Aseguramos que el juego est� en marcha
    }

    public void UpdateState(GameManager2 gameManager)
    {
        // Aqu� podemos manejar las interacciones mientras el juego est� en marcha
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si presionamos Escape, entramos al estado de pausa
            gameManager.SetState(new PauseState());
        }
    }

    public void ExitState(GameManager2 gameManager)
    {
        Debug.Log("Saliendo del estado de juego.");
        Time.timeScale = 1;  // Aseguramos que el juego est� en marcha al salir
    }
}