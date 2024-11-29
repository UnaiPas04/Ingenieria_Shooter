using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooleableObject
{
    public void setActive(bool b);
    //activo o no (si no esta activo se puede reciclar en el pool)

    public bool isActive();

    public void reset();
    //al desactivarlo le ponemos valores que se hayan podido cambiar, 
    //para q cuando se invoque este nuevecito
}
