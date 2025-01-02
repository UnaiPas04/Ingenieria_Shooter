using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShootingCommand : ICommand
{
    ArmaJugador armaJugador;

    public StartShootingCommand(ArmaJugador armaJugador)
    {
        this.armaJugador = armaJugador;
    }

    public void Execute()
    {
        armaJugador.ApretarGatillo();
    }
}
