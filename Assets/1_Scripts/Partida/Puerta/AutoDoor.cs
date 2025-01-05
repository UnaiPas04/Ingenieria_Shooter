using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
 public Animator doorAnim;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.ResetTrigger("PuertaCerrar");
            doorAnim.SetTrigger("PuertaAbrir");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.ResetTrigger("PuertaAbrir");
            doorAnim.SetTrigger("PuertaCerrar");
        }
    }
}
