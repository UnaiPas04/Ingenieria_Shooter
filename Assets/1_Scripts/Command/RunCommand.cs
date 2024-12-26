using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCommand : ICommand
{
    private Player_Movement player_Movement;

    public RunCommand(Player_Movement player_Movement)
    {
        this.player_Movement = player_Movement;
    }

    public void Execute()
    {
        if (player_Movement.isRunning)
        {
            player_Movement.StopRun();
        }
        else
        {
            player_Movement.StartRun();
        }
    }
}
