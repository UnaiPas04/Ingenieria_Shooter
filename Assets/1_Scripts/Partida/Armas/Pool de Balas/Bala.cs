using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour,IPooleableObject
{
    private bool active=false;

    public IPool pool;

    private void Update()
    {
        if (transform.position.y < -8)
        {
            pool?.release(this);
        }
    }


    public void setActive(bool b)
    {
        active= b;
        gameObject.SetActive(b);
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

    public IPooleableObject Clone()
    {
        GameObject copia = Instantiate(gameObject);
        Bala bala = copia.GetComponent<Bala>();
        return bala;
    }
}
