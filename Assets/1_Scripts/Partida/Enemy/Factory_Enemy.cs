using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory_Enemy : MonoBehaviour
{
    public static FlyWeightEnemy _FW_Enemy;
    GameObject GO_FW_Enemy;

    private void Awake()
    {
        if (_FW_Enemy == null) //nos aseguramos de q haya 1
        {
            _FW_Enemy = GO_FW_Enemy.GetComponent<FlyWeightEnemy>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static FlyWeightEnemy GetEnemy()
    {
        return _FW_Enemy;
    }
}
