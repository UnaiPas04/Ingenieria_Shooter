using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Healthbar healthbar;

    void Start()
    {
        playerHealth.AddObserver(healthbar);
    }
}
