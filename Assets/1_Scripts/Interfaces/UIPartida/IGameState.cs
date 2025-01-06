using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState
{
    void EnterState(GameManager2 gameManager);   // Al entrar al estado
    void UpdateState(GameManager2 gameManager);  // Actualización del estado
    void ExitState(GameManager2 gameManager);    // Al salir del estado
}
