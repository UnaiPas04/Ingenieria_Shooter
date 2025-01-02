using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopShootingCommand : ICommand
{
    private ArmaJugador armaJugador;

    public StopShootingCommand(ArmaJugador armaJugador)
    {
        this.armaJugador = armaJugador;
    }

    public void Execute()
    {
        armaJugador.SoltarGatillo();
    }
}
