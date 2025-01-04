using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    public float MaskDistanceMask;//cuanto hay que mover la mascara para q quede la barra ocluida totalmente
    private LifePoints lifePoints_obj;
    public Transform mask_transform;
    public Transform content_transform;
    public TextMeshProUGUI texto;

    void Start()
    {
        lifePoints_obj= GetComponent<LifePoints>();
        updateLifeBar();
    }
    
    public void updateText(int lifePoints)
    {
        //Texto 
        texto.text = lifePoints.ToString();
    }
    public void updateLifeBar() //se llama al recibir daño
    {
        //Barra de vida
        Vector3 p = mask_transform.localPosition;
        float d = - MaskDistanceMask + MaskDistanceMask * lifePoints_obj.GetPercent();
        p.x = d;
        mask_transform.localPosition = p;
        p.x *= -1;
        p.x/=mask_transform.localScale.x;
        content_transform.localPosition = p;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bala")
        {
            Bala bala=other.GetComponent<Bala>();

            if (bala!=null)
            {
                int lifePoints = lifePoints_obj.DecreaseLifePoints(bala.damage);
                
                bala.Destruir();
                updateLifeBar();
                updateText(lifePoints);

                if (lifePoints == 0)
                {
                    Muerte();
                }
            }
            else
            {
                Debug.LogError("Bala sin componente de tipo bala");
            }
        }
    }

    public void Muerte()
    {
        if (this.tag == "Enemy")
        {
            //Destruir Enemigo
            Destroy(this.gameObject);
            //Indicar que hay 1 menos
        }
        else if (this.tag == "Player")
        {
            //Mostrar pantalla de derrota
        }
    }
}