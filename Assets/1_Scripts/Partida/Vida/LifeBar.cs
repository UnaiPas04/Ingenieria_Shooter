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
    private void Update()
    {
        updateLifeBar();
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

        //Texto 
        texto.text = lifePoints_obj.GetLifePoints().ToString();
    }
}