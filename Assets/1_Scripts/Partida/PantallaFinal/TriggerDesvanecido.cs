using UnityEngine;

public class TriggerDesvanecido : MonoBehaviour
{
    public Desvanecido desvanecido; // Referencia al script de desvanecido

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            desvanecido.IniciarDesvanecido();
        }
    }
}
