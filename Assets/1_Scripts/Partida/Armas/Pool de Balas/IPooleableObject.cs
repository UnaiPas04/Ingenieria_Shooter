using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooleableObject
{
    public void setActive(bool b);

    public bool isActive();

    public void reset();
}
