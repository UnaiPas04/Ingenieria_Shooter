using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponCommand : ICommand
{
    private ArmaJugador armaJugador;
    private int index;
    private float cooldown = 1.5f;
    private static float lastSwitch;

    public ChangeWeaponCommand(ArmaJugador armaJugador, int index)
    {
        this.armaJugador = armaJugador;
        this.index = index;
    }

    public void Execute()
    {
        if (Time.time - lastSwitch < cooldown)
        {
            armaJugador.CambiarArma(index);
            lastSwitch = Time.time;
        }
    }
}
