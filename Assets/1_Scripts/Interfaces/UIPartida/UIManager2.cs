using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class UIManager2 : MonoBehaviour
{
    public static UIManager2 Instance;

    public GameObject PauseMenuPanel;  // Panel de pausa

    private void Awake()
    {
        Instance = this;
    }

    public void ShowPauseMenu()
    {
        PauseMenuPanel.SetActive(true);  // Mostrar el menú de pausa
    }

    public void HidePauseMenu()
    {
        PauseMenuPanel.SetActive(false);  // Ocultar el menú de pausa
    }
}
