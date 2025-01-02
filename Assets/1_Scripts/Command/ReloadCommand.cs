using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadCommand : ICommand
{
    private ArmaJugador armaJugador;

    public ReloadCommand(ArmaJugador armaJugador)
    {
        this.armaJugador = armaJugador;
    }

    public void Execute()
    {
        armaJugador.RecargarArma();
    }
}
