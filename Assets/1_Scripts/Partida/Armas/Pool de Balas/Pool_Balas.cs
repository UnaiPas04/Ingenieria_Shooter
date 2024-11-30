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
        return buscarBalaInactiva();
    }

    private IPooleableObject buscarBalaInactiva()
    {
        //devuelve la primera posicion inactiva que encuentra
        for (int i=0;i<pool.Length;i++)
        {
            if ( !pool[i].isActive())
            {
                return pool[i];
            }
        }
        return null;

    }
    public void release(IPooleableObject obj) 
    {
        //inactiva bala
        obj.setActive(false);
    }
}
