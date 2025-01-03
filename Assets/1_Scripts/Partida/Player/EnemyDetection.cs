using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public Camera playerCamera; // C�mara del jugador, asignar desde el inspector
    public float detectionRange = 100f; // Rango m�ximo de detecci�n
    public LayerMask enemyLayer; // Capa que contiene los enemigos

    void Update()
    {
        DetectVisibleEnemies();
    }

    void DetectVisibleEnemies()
    {
        // Calcular los planos del frustum de la c�mara
        Plane[] frustumPlanes = GeometryUtility.CalculateFrustumPlanes(playerCamera);

        // Obtener todos los colliders en el rango de detecci�n
        Collider[] hits = Physics.OverlapSphere(playerCamera.transform.position, detectionRange, enemyLayer);

        foreach (Collider hit in hits)
        {
            GameObject potentialEnemy = hit.gameObject;

            if (potentialEnemy.CompareTag("Enemy"))
            {
                // Verificar si est� dentro del frustum de la c�mara
                if (GeometryUtility.TestPlanesAABB(frustumPlanes, hit.bounds))
                {
                    
                }
            }
        }
    }
}