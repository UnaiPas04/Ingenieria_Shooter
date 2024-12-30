using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropiedadesArma : MonoBehaviour
{
    //Se le asigna a los prefabs de arma

    [HideInInspector]public float NumeroBalas;//cuantas balas quedan

    public List<Transform> PosicionCannon;

    private int cannonActual=0;

    public void Recargar(int n)
    {
        NumeroBalas = n;
    }

    public bool Disparar()//gasta una bala, te devuelve si pudo disparar
    {
        if (NumeroBalas > 0)
        {
            NumeroBalas--;
            return true;
        }
        else
        {
            return false;
        }
    }

    public Transform GetCannonActual()//va alternando entre todos los cañones
    {
        cannonActual=(cannonActual+1)%PosicionCannon.Count;

        return PosicionCannon[cannonActual];
    }
}
