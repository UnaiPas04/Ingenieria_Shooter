using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthObserver
{
    void OnHealthChange(int currentHealth, int maxHealth);

    void OnDeath();
}
