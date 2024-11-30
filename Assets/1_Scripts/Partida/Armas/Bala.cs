using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Bala : MonoBehaviour,IPooleableObject
{
    private bool active=false;

    public IPool pool;

    public float velocidad;
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

    public void inicializarVelocidad(float angulo)
    {
        float vx =Mathf.Cos(angulo/180*3.1415f)* velocidad;
        float vy = Mathf.Sin(angulo/180*3.1415f)* velocidad;
        GetComponent<Rigidbody>().velocity = new Vector3(vx,vy,0);
    }

    public IPooleableObject Clone()
    {
        GameObject copia = Instantiate(gameObject);
        Bala bala = copia.GetComponent<Bala>();
        return bala;
    }
}
