using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Balas : IPool
{
    Bala[] poolBalas;

    GameObject prefabBala;

    public Pool_Balas(int size, GameObject prefabBala)
    {
        //dependiendo del arma que escojas se usara un pool distinto
        //armas con mas balas requeriran un pool mas grande
        //cada arma tendra una bala caracteristica

        this.poolBalas = new Bala[size];
        this.prefabBala= prefabBala;
        inicializarPool();
    }
    private void inicializarPool()
    {
        for (int i = 0; i < poolBalas.Length; i++)
        {
            poolBalas[i] = new Bala(prefabBala);
        }
    }
    public IPooleableObject get()
    {
        return buscarBalaInactiva();
    }

    private Bala buscarBalaInactiva()
    {
        //devuelve la primera posicion inactiva que encuentra
        for (int i=0;i<poolBalas.Length;i++)
        {
            if ( !poolBalas[i].isActive())
            {
                return poolBalas[i];
            }
        }
        return null;

    }
    public void release(IPooleableObject obj) 
    {
        //inactiva bala

    }
}
