using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //VARIABLES INDIVIDUALES DE LOS ENEMIGOS
    public GameObject gameObject_Arma;
    [HideInInspector] public PropiedadesArma propiedadesArma;

    private float t = 0;
    private bool disparando=true;

    //VARIABLES COMUNES A TODOS LOS ENEMIGOS
    public static FlyWeightEnemy _FW_Enemy;


    private void Awake()
    {
        propiedadesArma = gameObject_Arma.GetComponent<PropiedadesArma>();

    }
    private void Start()
    {
        _FW_Enemy = Factory_Enemy.GetEnemy();

        RecargarArma();
    }

    public void RecargarArma() //cuando aprietas tecla de recargar
    {
        propiedadesArma.Recargar(_FW_Enemy.propiedadesArmas_Genericas.NumeroBalasMax);
    }
    public void Disparando(bool disp)
    {
        disparando = disp;
    }

    void GenerarBala()
    {
        if (propiedadesArma.Disparar())//si tiene balas en el cargador
        {
            CrearBala(propiedadesArma.GetCannonActual());
        }
    }

    Bala CrearBala(Transform t)//le pasamos el transform de la punta del arma
    {
        Bala bala = _FW_Enemy.CrearBala(t);

        return bala;
    }

    private void FixedUpdate()
    {
        if (disparando)
        {
            t += Time.fixedDeltaTime;

            if (t > _FW_Enemy.propiedadesArmas_Genericas.RatioBalas)
            {
                t = 0;

                GenerarBala();
            }
            _FW_Enemy.poolBalas.MostrarEstado();
        }
    }

    

    public void Disparar()
    {
        _FW_Enemy = Factory_Enemy.GetEnemy();
    }

    public void ejemploMetodo()
    {
        _FW_Enemy.ejemplometodo(this);
    }
}
