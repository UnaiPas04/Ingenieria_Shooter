using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaJugador : MonoBehaviour
{
    public GameObject prefab_Bala;
    public List<GameObject> gameObjects_Armas; // Lista dinámica de armas
    private List<bool> armasDisponibles; // Estado de disponibilidad de cada arma

    private Pool poolBalas;

    public PropiedadesArma propiedadesArmaEquipada;
    public PropiedadesArmas_Genericas propiedadesGenericasArmaEquipada;

    public Transform weaponTransform;
    public float reloadAnimDuration = 1.5f;
    public Vector3 reloadOffset = new Vector3(0, -0.5f, 0);

    float ratio = 0;
    float t = 0;
    private int armaSeleccionada = -1;
    private bool disparando;
    private bool reloading;

    void Start()
    {
        poolBalas = new Pool(60, prefab_Bala);

        // Desactiva todas las armas al inicio
        for (int i = 0; i < gameObjects_Armas.Count; i++)
        {
            gameObjects_Armas[i].SetActive(false);
        }

        // Inicializa armas como no disponibles
        armasDisponibles = new List<bool>();
        for (int i = 0; i < gameObjects_Armas.Count; i++)
        {
            armasDisponibles.Add(false);
        }

        armaSeleccionada = -1; // Ninguna arma seleccionada
    }

    public void CambiarArma(int nuevaArma) // Cambia el arma equipada
    {
        if (nuevaArma >= 0 && nuevaArma < gameObjects_Armas.Count && armasDisponibles[nuevaArma])
        {
            if (armaSeleccionada != nuevaArma)
            {
                armaSeleccionada = nuevaArma;
                for (int i = 0; i < gameObjects_Armas.Count; i++)
                {
                    gameObjects_Armas[i]?.SetActive(i == nuevaArma); // Activa solo el arma seleccionada
                }

                propiedadesArmaEquipada = gameObjects_Armas[nuevaArma].GetComponent<PropiedadesArma>();
                propiedadesGenericasArmaEquipada = gameObjects_Armas[nuevaArma].GetComponent<PropiedadesArmas_Genericas>();

                ratio = propiedadesGenericasArmaEquipada.RatioBalas;
            }
        }
        else
        {
            Debug.LogWarning($"No puedes cambiar al arma {nuevaArma}, no está disponible.");
        }
    }

    public void RecargarArma() // Recarga el arma actual
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
        while (time < reloadAnimDuration / 2)
        {
            weaponTransform.localPosition = Vector3.Lerp(position, position + reloadOffset, time / (reloadAnimDuration / 2));
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        time = 0f;
        while (time < reloadAnimDuration / 2)
        {
            weaponTransform.localPosition = Vector3.Lerp(position + reloadOffset, position, time / (reloadAnimDuration / 2));
            time += Time.deltaTime;
            yield return null;
        }

        weaponTransform.localPosition = position;

        propiedadesArmaEquipada.Recargar(propiedadesGenericasArmaEquipada.NumeroBalasMax);

        reloading = false;
    }

    public void ApretarGatillo() // Cuando se aprieta el botón de disparar
    {
        disparando = true;
    }

    public void SoltarGatillo() // Cuando se suelta el botón de disparar
    {
        disparando = false;
    }

    void GenerarBala()
    {
        if (propiedadesArmaEquipada.Disparar()) // Si tiene balas en el cargador
        {
            CrearBala(propiedadesArmaEquipada.GetCannonActual(), propiedadesGenericasArmaEquipada.DanoBala);
        }
    }

    Bala CrearBala(Transform t, int dano) // Crea una bala
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
                t -= ratio;

                GenerarBala();
            }
            poolBalas.MostrarEstado();
        }
    }

    public bool isReloading() { return reloading; }

    // NUEVO: Método para recoger armas
    public void RecogerArma(int armaIndex)
    {
        if (armaIndex >= 0 && armaIndex < gameObjects_Armas.Count && !armasDisponibles[armaIndex])
        {
            // Activa el arma recogida
            armasDisponibles[armaIndex] = true;
            gameObjects_Armas[armaIndex].SetActive(true);

            // Cambia automáticamente al arma recogida
            CambiarArma(armaIndex);

            Debug.Log($"Arma con índice {armaIndex} recogida y activada.");
        }
        else
        {
            Debug.LogWarning($"El índice {armaIndex} ya está disponible o no es válido.");
        }
    }
}
