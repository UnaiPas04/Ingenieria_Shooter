using UnityEngine;

public class RecogerArma : MonoBehaviour
{
    public int armaIndex;               // Índice del arma en la lista de armas del jugador
    public GameObject mensajeUI;        // Objeto del mensaje en pantalla
    private bool jugadorCerca = false;  // Indica si el jugador está en el rango del arma

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha entrado en el rango del arma.");
            jugadorCerca = true;
            if (mensajeUI != null)
            {
                mensajeUI.SetActive(true); // Activa el mensaje en pantalla
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha salido del rango del arma.");
            jugadorCerca = false;
            if (mensajeUI != null)
            {
                mensajeUI.SetActive(false); // Desactiva el mensaje
            }
        }
    }


    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            ArmaJugador jugador = FindObjectOfType<ArmaJugador>();
            if (jugador != null)
            {
                jugador.RecogerArma(armaIndex);
                if (mensajeUI != null)
                {
                    mensajeUI.SetActive(false); // Oculta el mensaje
                }
                Destroy(gameObject); // Destruye el arma
                Debug.Log("El arma ha sido recogida y eliminada del mapa.");
            }
        }
    }
}
