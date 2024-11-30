using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pool : IPool
{
    IPooleableObject[] pool;

    private IPooleableObject prototipo;

    private int _activeObjects;

    public Pool(int size, GameObject prefab)
    {
        //dependiendo del arma que escojas se usara un pool distinto
        //armas con mas balas requeriran un pool mas grande
        //cada arma tendra una bala caracteristica

        this.pool = new IPooleableObject[size];
        this.prototipo = prefab.GetComponent<IPooleableObject>();
        inicializarPool();
        this._activeObjects = 0;
    }
    private void inicializarPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = prototipo.Clone();
        }
    }
    public IPooleableObject get()
    {
        //devuelve la primera posicion inactiva que encuentra
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].isActive())
            {
                pool[i].setActive(true);
                _activeObjects++;

                return pool[i];
            }
        }
        return null;
    }

    public void release(IPooleableObject objeto) 
    {
        //inactiva bala
        objeto.setActive(false);

        _activeObjects -= 1;

        objeto.reset();
    }


    public void MostrarEstado()
    {
        Debug.Log("---ESTADO_POOL--- \n"+_activeObjects+" de "+pool.Length+ "\n-----------------");
    }
}
