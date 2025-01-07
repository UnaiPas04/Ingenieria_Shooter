using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeBar : MonoBehaviour, IHealthObserver
{
    public float MaskDistanceMask;//cuanto hay que mover la mascara para q quede la barra ocluida totalmente
    private LifePoints lifePoints_obj;
    public Transform mask_transform;
    public Transform content_transform;
    public TextMeshProUGUI texto;

    void Start()
    {
        lifePoints_obj= GetComponent<LifePoints>();

        if(lifePoints_obj != null )
        {
            lifePoints_obj.AddObserver(this);
            OnHealthChange(lifePoints_obj.getLifePoints(), lifePoints_obj.maxLifePoints);
        }
    }
    
    public void updateText(int lifePoints)
    {
        //Texto 
        texto.text = lifePoints.ToString();
    }
    public void OnHealthChange(int currentHealth, int maxHealth) //se llama al recibir daño
    {
        //Barra de vida
        Vector3 p = mask_transform.localPosition;
        float d = -MaskDistanceMask + MaskDistanceMask * ((float)currentHealth / maxHealth);
        p.x = d;
        mask_transform.localPosition = p;
        p.x *= -1;
        p.x/=mask_transform.localScale.x;
        content_transform.localPosition = p;

        texto.text = currentHealth.ToString();
    }

    public void OnDeath()
    {
        if (this.tag == "Enemy")
        {
            Debug.Log("Enemy death.");
            //Destruir Enemigo
            Destroy(this.gameObject);
        }
        else if (this.tag == "Player")
        {
            //Mostrar pantalla de derrota
            Debug.Log("Player death.");

            if (GameOverManager.Instance != null)
            {
                GameOverManager.Instance.TriggerGameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bala")
        {
            Bala bala=other.GetComponent<Bala>();

            if (bala!=null)
            {
                /*
                int lifePoints = lifePoints_obj.DecreaseLifePoints(bala.damage);
                
                bala.Destruir();
                updateLifeBar();
                updateText(lifePoints);

                if (lifePoints == 0)
                {
                    Muerte();
                }
                */
                Debug.Log("Daño de la bala: " + bala.damage);
                lifePoints_obj.DecreaseLifePoints(bala.damage);
                bala.Destruir();

            }
            else
            {
                Debug.LogError("Bala sin componente de tipo bala");
            }
        }
    }
}