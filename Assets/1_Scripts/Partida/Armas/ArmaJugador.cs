using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaJugador : MonoBehaviour
{
    public GameObject prefab_Bala;
    public List<GameObject> gameObjects_Armas;

    private int armaSeleccionada=-1;
    private Pool poolBalas;

    PropiedadesArma propiedadesArmaEquipada;

    public bool disparando;
    public bool recargar;
    public int arma=0;

    float ratio = 0;
    float t=0;

    void Start()
    {
        poolBalas = new Pool(60,prefab_Bala);

        CambiarArma(0);
    }

    public void CambiarArma(int nuevaArma)//se llama con el input del teclado
    {
        if (armaSeleccionada == nuevaArma) return;
        if (nuevaArma > 2) nuevaArma = 2;

        armaSeleccionada= nuevaArma;
        for (int i=0;i< gameObjects_Armas.Count;i++)
        {
            //pone visible el arma seleccionada
            gameObjects_Armas[i].SetActive(i== nuevaArma);
        }

        propiedadesArmaEquipada = gameObjects_Armas[nuevaArma].GetComponent<PropiedadesArma>();
        ratio = propiedadesArmaEquipada.RatioBalas;
    }

    public void RecargarArma() //cuando aprietas tecla de recargar
    {
        propiedadesArmaEquipada.Recargar();
    }
    public void ApretarGatillo()//cuando aprietas tecla de disparar
    {
        disparando = true;
    }

    public void SoltarGatillo() //cuando sueltas tecla de disparar
    {
        disparando = false;
    }

    void GenerarBala()
    {
        if (propiedadesArmaEquipada.Disparar())//si tiene balas en el cargador
        {
            CrearBala(propiedadesArmaEquipada.GetCannonActual());
        }
    }

    Bala CrearBala(Transform t)//le pasamos el transform de la punta del arma
    {
        Bala bala = (Bala)poolBalas.get();
        if (bala)
        {
            bala.pool = poolBalas;

            bala.transform.position = t.position;
            bala.transform.eulerAngles = t.eulerAngles;
            bala.inicializarVelocidad();
        }

        return bala;
    }

    private void FixedUpdate()
    {
        if (disparando)
        {
            t += Time.fixedDeltaTime;

            if (t > ratio)
            {
                t-=ratio;

                GenerarBala();
            }
            poolBalas.MostrarEstado();
        }
    }
}
