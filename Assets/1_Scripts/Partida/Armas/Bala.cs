using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Bala : MonoBehaviour,IPooleableObject
{
    private bool active=false;

    public int damage = 10; //daño de la bala

    public IPool pool;

    public float velocidad;

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

    public void inicializarVelocidad()
    {
        // float vx =Mathf.Cos(angulo/180*3.1415f)* velocidad;
        //float vz = -Mathf.Sin(angulo/180*3.1415f)* velocidad;
        StartCoroutine(EsperarEInicializar());
    }

    public IPooleableObject Clone()
    {
        GameObject copia = Instantiate(gameObject);
        Bala bala = copia.GetComponent<Bala>();
        return bala;
    }
    IEnumerator EsperarEInicializar()
    {
        yield return new WaitForSeconds(0.01f);

        GetComponent<Rigidbody>().velocity = transform.right * velocidad;
        StartCoroutine(EsperarYDestruir());

    }
    IEnumerator EsperarYDestruir()
    {
        yield return new WaitForSeconds(0.8f);
        Destruir();
    }

    public void Destruir()
    {
        pool?.release(this);
    }

    public void OnCollisionEnter(Collision collision)
    {
      /*  if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }

        pool.release(this);*/
    }
}
