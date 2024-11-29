using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPool
{
    public IPooleableObject get();

    public void release(IPooleableObject obj);
}
