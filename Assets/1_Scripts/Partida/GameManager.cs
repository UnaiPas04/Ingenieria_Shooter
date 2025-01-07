using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject introScreen;

    void Start()
    {
        introScreen.SetActive(true);
        GameStateManager.Instance.PauseGame();
    }

    public void Continuar()
    {
        introScreen.SetActive(false);
        GameStateManager.Instance.StartGame();
    }
}
