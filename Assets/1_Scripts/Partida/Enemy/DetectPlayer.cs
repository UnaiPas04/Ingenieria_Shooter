using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    //Si el jugador es el objeto mas cercano en un cono le disparamos y perseguimos
    //Es decir si no hay muros en medio

    Enemy enemy;
    public float detectionRadius = 10f;  // Radio de la esfera para detectar objetos cercanos
    private int p = 50; //probaabilidad de que compruebe la colision (eficiencia)
    public LayerMask exclusionLayer1; 
    public LayerMask exclusionLayer2;

    Transform posJ;
    private void Start()
    {
        enemy= GetComponent<Enemy>();
        posJ = Factory_Enemy.GetEnemy().posicionJugador;
    }
    void Update()
    {
        
        int rand= Random.Range(0, 100);
        if (rand >= p) //a menor p menos veces se ejecuta esta operacion (es muy costosa y habrá muchos enemigos)
        {
            // Llamamos a la función que busca el objeto más cercano dentro del cono
            CheckClosestObjectInFront();
        }
    }

    void CheckClosestObjectInFront()
    {
        LayerMask mask = ~(exclusionLayer1 | exclusionLayer2);

        // Dirección hacia el transform objetivo (posJ)
        Vector3 directionToTarget = (posJ.position - transform.position).normalized;

        // Crear el rayo
        Ray ray = new Ray(transform.position, directionToTarget);

        // Inicializamos variables
        bool jugadorEncontrado = false;
        float closestDistance = detectionRadius;
        RaycastHit closestHit;
        string t="";
        // Lanzamos el rayo y obtenemos todos los objetos impactados
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);

        foreach (RaycastHit hit in hits)
        {
            // Calculamos la distancia desde el origen hasta el punto de impacto
            float distance = Vector3.Distance(transform.position, hit.point);

            // Si el objeto está más cerca que el más cercano previamente registrado
            
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestHit = hit;

                t = closestHit.collider.tag;

                Debug.Log(t);
            }
        }

        jugadorEncontrado = t=="Player";

        // Actualizamos las acciones del enemigo en función del resultado
        enemy.Disparando(jugadorEncontrado);
        enemy.MoverseHaciaJugador(jugadorEncontrado);
    }
}
