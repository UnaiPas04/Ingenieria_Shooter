using UnityEngine;

public class RecogerArma : MonoBehaviour
{
    public int armaIndex; // Índice del arma en la lista de armas del jugador
    public GameObject mensajeUI; // Objeto del mensaje en pantalla
    private bool jugadorCerca = false; // Indica si el jugador está en el rango del arma

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha entrado en el rango del arma.");
            jugadorCerca = true;
            if (mensajeUI != null)
            {
                mensajeUI.SetActive(true); // Activa el mensaje en pantalla
                Debug.Log("Mensaje activado."); // Confirmación
            }
            else
            {
                Debug.LogWarning("mensajeUI no está asignado.");
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
                Debug.Log("Mensaje desactivado."); // Confirmación
            }
            else
            {
                Debug.LogWarning("mensajeUI no está asignado.");
            }
        }
    }


    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("El jugador ha presionado la tecla 'E'.");
            ArmaJugador jugador = FindObjectOfType<ArmaJugador>();
            if (jugador != null)
            {
                Debug.Log("Jugador encontrado, añadiendo arma al inventario.");
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
