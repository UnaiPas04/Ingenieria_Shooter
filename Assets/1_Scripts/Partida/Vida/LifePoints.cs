using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePoints : MonoBehaviour
{
    public int MaxLifePoints=100;//inicializas en el inspector a cada enemigo
    private int lifePoints;

    private void Awake()
    {
        lifePoints = MaxLifePoints;
    }

    public int GetLifePoints()
    {
        return lifePoints;
    }

    public bool DecreaseLifePoints(int damage)
    {
        if (lifePoints > damage)
        {
            lifePoints-=damage;
            return true;
        }
        else
        {
            lifePoints = 0;
            return false;
        }
    }

    public bool IsAlive()
    {
        return lifePoints > 0;
    }
}
