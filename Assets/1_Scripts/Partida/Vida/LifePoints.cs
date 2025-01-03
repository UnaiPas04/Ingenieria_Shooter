using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePoints : MonoBehaviour
{
    public int MaxLifePoints=100;//inicializas en el inspector a cada enemigo
    public int lifePoints;

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
            return true;//vivo
        }
        else
        {
            lifePoints = 0;
            return false;//muerto
        }
    }

    public bool IsAlive()
    {
        return lifePoints > 0;
    }

    public float GetPercent()
    {
        return (float)lifePoints / (float)MaxLifePoints;
    }
}
