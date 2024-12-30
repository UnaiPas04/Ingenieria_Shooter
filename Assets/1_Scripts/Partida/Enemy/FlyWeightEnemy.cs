using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWeightEnemy:MonoBehaviour //monoBehaviour para facilitar la inicialización desde el inspector
{
    //VARIABLES COMUNES A TODOS LOS ENEMIGOS
    public GameObject prefab_Bala;

    public Pool poolBalas;

    [HideInInspector] public PropiedadesArmas_Genericas propiedadesArmas_Genericas;

    private void Awake()
    {
        propiedadesArmas_Genericas=GetComponent<PropiedadesArmas_Genericas>();

        poolBalas = new Pool(100, prefab_Bala);
    }


    //METODOS COMUNES A TODOS LOS SOLDADOS
    public void ejemplometodo(Enemy enemy)
    {

    }

    public Bala CrearBala(Transform t)//le pasamos el transform de la punta del arma
    {
        Bala bala = (Bala)poolBalas.get();
        if (bala)
        {

            bala.damage = propiedadesArmas_Genericas.DanoBala;
            bala.pool = poolBalas;

            bala.transform.position = t.position;
            bala.transform.eulerAngles = t.eulerAngles;
            bala.inicializarVelocidad();
        }

        return bala;
    }
}
