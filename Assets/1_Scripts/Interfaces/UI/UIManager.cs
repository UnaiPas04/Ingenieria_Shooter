using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject MainMenuPanel;
    public GameObject CreditsPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowMainMenu()
    {
        MainMenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void HideMainMenu()
    {
        MainMenuPanel.SetActive(false);
    }



    public void ShowCredits()
    {
        CreditsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void HideCredits()
    {
        CreditsPanel.SetActive(false);
    }
}
