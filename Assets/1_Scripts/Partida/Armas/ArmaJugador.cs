using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaJugador : MonoBehaviour
{
    public GameObject prefab_Bala;
    public List<GameObject> gameObjects_Armas;
    
    private Pool poolBalas;

    public PropiedadesArma propiedadesArmaEquipada;
    public PropiedadesArmas_Genericas propiedadesGenericasArmaEquipada;

    public Transform weaponTransform;
    public float reloadAnimDuration = 1.5f;
    public Vector3 reloadOffset = new Vector3(0, -0.5f, 0);

    float ratio = 0;
    float t=0;
    private int armaSeleccionada = -1;
    private bool disparando;
    private bool reloading;


    void Start()
    {
        poolBalas = new Pool(60,prefab_Bala);

        CambiarArma(0);
    }

    public void CambiarArma(int nuevaArma)//se llama con el input del teclado
    {
        if (nuevaArma > 2) nuevaArma = 2;

        if (armaSeleccionada != nuevaArma)
        {
            armaSeleccionada = nuevaArma;
            for (int i = 0; i < gameObjects_Armas.Count; i++)
            {
                //pone visible el arma seleccionada
                gameObjects_Armas[i].SetActive(i == nuevaArma);
            }

            propiedadesArmaEquipada = gameObjects_Armas[nuevaArma].GetComponent<PropiedadesArma>();
            propiedadesGenericasArmaEquipada = gameObjects_Armas[nuevaArma].GetComponent<PropiedadesArmas_Genericas>();

            ratio = propiedadesGenericasArmaEquipada.RatioBalas;
        }
        else
        {
            propiedadesArmaEquipada = gameObjects_Armas[nuevaArma].GetComponent<PropiedadesArma>();
            propiedadesGenericasArmaEquipada = gameObjects_Armas[nuevaArma].GetComponent<PropiedadesArmas_Genericas>();

            ratio = propiedadesGenericasArmaEquipada.RatioBalas;
        }
    }

    public void RecargarArma() //cuando aprietas tecla de recargar
    {
        if (!reloading)
        {
            StartCoroutine(ReloadAnimation());
        }
    }

    IEnumerator ReloadAnimation()
    {
        reloading = true;

        Vector3 position = weaponTransform.localPosition;

        float time = 0f;
        while(time < reloadAnimDuration / 2)
        {
            weaponTransform.localPosition = Vector3.Lerp(position, position + reloadOffset, time / (reloadAnimDuration / 2));
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        time = 0f;
        while(time < reloadAnimDuration / 2)
        {
            weaponTransform.localPosition = Vector3.Lerp(position + reloadOffset, position, time / (reloadAnimDuration / 2));
            time += Time.deltaTime;
            yield return null;
        }

        weaponTransform.localPosition = position;

        propiedadesArmaEquipada.Recargar(propiedadesGenericasArmaEquipada.NumeroBalasMax);

        reloading = false;
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
            CrearBala(propiedadesArmaEquipada.GetCannonActual(),propiedadesGenericasArmaEquipada.DanoBala);
        }
    }

    Bala CrearBala(Transform t,int dano)//le pasamos el transform de la punta del arma
    {
        Bala bala = (Bala)poolBalas.get();
        if (bala)
        {
            bala.damage = dano;
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

    public bool isReloading() { return reloading; }
}
