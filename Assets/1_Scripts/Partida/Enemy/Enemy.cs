using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealthObserver
{
    // VARIABLES INDIVIDUALES DE LOS ENEMIGOS
    public GameObject gameObject_Arma;
    [HideInInspector] public PropiedadesArma propiedadesArma;
    Rigidbody rigidbody;

    private Animator animator;
    private bool isDead = false;

    private LifePoints lifePoints; // Referencia al sistema de vida

    private float t = 0;
    private bool disparando = false;
    private bool recargando = false;
    private bool persiguiendo = false;

    // VARIABLES COMUNES A TODOS LOS ENEMIGOS
    public static FlyWeightEnemy _FW_Enemy;

    private void Awake()
    {
        propiedadesArma = gameObject_Arma.GetComponent<PropiedadesArma>();
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Obtén el Animator del modelo
        lifePoints = GetComponent<LifePoints>(); // Obtén el componente LifePoints

        if (lifePoints != null)
        {
            lifePoints.AddObserver(this); // Suscribirse a los cambios de vida
        }
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
        if (isDead) return; // No hacer nada si el enemigo está muerto

        // Mirar hacia el jugador
        Transform target = _FW_Enemy.posicionJugador;
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPosition);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y - 90, 0f);

        if (persiguiendo)
        {
            Vector3 v = targetPosition - transform.position;
            rigidbody.velocity = v * 0.2f;

            // Activar animación de correr
            animator.SetBool("IsRunning", true);
            Debug.Log($"IsRunning: {animator.GetBool("IsRunning")}");
        }
        else
        {
            rigidbody.velocity = Vector3.zero;

            // Activar animación de idle
            animator.SetBool("IsRunning", false);
        }
    }

    public void OnHealthChange(int currentHealth, int maxHealth)
    {
        if (currentHealth <= 0)
        {
            Die(); // Llama al método Die cuando la vida llegue a 0
        }
    }

    public void OnDeath()
    {
        // Este método se llama automáticamente por LifePoints cuando el enemigo muere
        Die();
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
        if (propiedadesArma.Disparar()) // Si tiene balas en el cargador
        {
            _FW_Enemy.CrearBala(propiedadesArma.GetCannonActual());
        }
        else
        {
            StartCoroutine(EsperarYRecargar());
        }
    }

    public void MoverseHaciaJugador(bool m)
    {
        persiguiendo = m;
    }

    private void Die()
    {
        if (isDead) return; // Evita múltiples llamadas a Die
        isDead = true; // Marcar como muerto

        // Detener el movimiento
        rigidbody.velocity = Vector3.zero;
        rigidbody.isKinematic = true;

        // Activar la animación de muerte
        animator.SetBool("Dead", true);

        // Desactivar este script para evitar más lógica de movimiento
        this.enabled = false;

        // Destruir el enemigo después de 3 segundos
        Destroy(gameObject, 3f);
    }

}
