using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //VARIABLES INDIVIDUALES DE LOS ENEMIGOS
    public GameObject gameObject_Arma;
    [HideInInspector] public PropiedadesArma propiedadesArma;
    Rigidbody rigidbody;
  //  public Collider areaVision;//si el jugador esta dentro, dispara, y se mueve hacia él

    private float t = 0;
    private bool disparando=false;
    private bool recargando = false;
    private bool persiguiendo = false;

    //VARIABLES COMUNES A TODOS LOS ENEMIGOS
    public static FlyWeightEnemy _FW_Enemy;


    private void Awake()
    {
        propiedadesArma = gameObject_Arma.GetComponent<PropiedadesArma>();
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _FW_Enemy = Factory_Enemy.GetEnemy();

        StartCoroutine(EsperarYRecargar());
    }
    private void FixedUpdate()
    {
        if (disparando && !recargando)
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
    private void Update()
    {
        //Mirar hacia el jugador
        Transform target=_FW_Enemy.posicionJugador;
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPosition);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y-90, 0f);

        if (persiguiendo)
        {
            Vector3 v= targetPosition - transform.position;

            rigidbody.velocity = v*0.2f;
          
        }
        else rigidbody.velocity = new Vector3();
    }

    IEnumerator EsperarYRecargar()
    {
        recargando = true; 
        yield return new WaitForSeconds(0.8f);
        propiedadesArma.Recargar(_FW_Enemy.propiedadesArmas_Genericas.NumeroBalasMax);
        recargando = false;
    }
    public void Disparando(bool disp)
    {
        disparando = disp;
    }

    void GenerarBala()
    {
        if (propiedadesArma.Disparar())//si tiene balas en el cargador
        {
            _FW_Enemy.CrearBala(propiedadesArma.GetCannonActual());
        }
        else
        {
            StartCoroutine(EsperarYRecargar());
        }
    }

    public void ejemploMetodo()
    {
        _FW_Enemy.ejemplometodo(this);
    }

    public void MoverseHaciaJugador(bool m)
    {
        persiguiendo = m;
    }
}
