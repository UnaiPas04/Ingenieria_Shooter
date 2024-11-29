using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : IPooleableObject
{
    private bool active=false;

    private GameObject objetoBala;

    public Bala(GameObject prefabBala)
    {
        objetoBala=prefabBala;
    }
    public void setActive(bool b)
    {
        active= b;
    }

    public bool isActive()
    {
        return active;
    }

    public void reset()
    {
        //ponerle valores de fabrica :)

        //velocidad

    }

}
