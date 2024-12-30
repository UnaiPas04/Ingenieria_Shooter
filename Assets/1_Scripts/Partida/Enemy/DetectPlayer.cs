using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    //Si el jugador es el objeto mas cercano en un cono le disparamos y perseguimos
    //Es decir si no hay muros en medio

    Enemy enemy;
    public float detectionRadius = 10f;  // Radio de la esfera para detectar objetos cercanos
    public float detectionAngle = 45f;   // Ángulo de visión (45 grados)
    private int p = 50; //probaabilidad de que compruebe la colision (eficiencia)
    public LayerMask exclusionLayer1; 
    public LayerMask exclusionLayer2;

    private void Awake()
    {
        enemy= GetComponent<Enemy>();
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
        // Detectamos todos los colliders dentro del radio
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius,mask);

        Collider closestCollider = null;
        float closestDistance = Mathf.Infinity;

        // Dirección hacia donde estamos mirando
        Vector3 lookDirection = transform.right; //flecha roja del inspector xd

        // Iteramos a través de todos los colliders
        foreach (Collider col in colliders)
        {
            // Calculamos el ángulo entre objeto y vector de mirada
            Vector3 directionToCollider = col.transform.position - transform.position;
            float angle = Vector3.Angle(lookDirection, directionToCollider);

            // Si el objeto está dentro del ángulo de visión (45º) y es el más cercano, lo almacenamos
            if (angle <= detectionAngle / 2f)
            {
                float distance = directionToCollider.magnitude;

                // Si es el objeto más cercano, lo guardamos
                if (distance < closestDistance)
                {
                    closestCollider = col;
                    closestDistance = distance;
                }
            }
            
        }
        bool jugadorEncontrado = closestCollider != null && closestCollider.tag == "Player";

        enemy.Disparando(jugadorEncontrado);
        enemy.MoverseHaciaJugador(jugadorEncontrado);
    }
}
