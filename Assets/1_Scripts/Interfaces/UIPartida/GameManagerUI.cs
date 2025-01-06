using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance;

    private IGameState currentState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetState(new GameState());  // Estado inicial
    }

    public void SetState(IGameState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = newState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }
    public void GoToGame() => SetState(new GameState());

}