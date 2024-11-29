using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPool
{
    public IPooleableObject get();
    //devuelve un objeto inactivo
    public void release(IPooleableObject obj);
    //objeto vuelve a la pool
}
