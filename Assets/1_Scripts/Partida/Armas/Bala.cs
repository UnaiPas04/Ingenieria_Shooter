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

        GetComponent<TrailRenderer>().Clear();
    }

    public void inicializarVelocidad(float angulo)
    {
        float vx =Mathf.Cos(angulo/180*3.1415f)* velocidad;
        float vz = -Mathf.Sin(angulo/180*3.1415f)* velocidad;
        GetComponent<Rigidbody>().velocity = new Vector3(vx,0,vz);
    }

    public IPooleableObject Clone()
    {
        GameObject copia = Instantiate(gameObject);
        Bala bala = copia.GetComponent<Bala>();
        return bala;
    }
}
