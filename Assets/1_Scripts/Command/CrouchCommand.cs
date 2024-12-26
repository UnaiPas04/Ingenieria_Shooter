using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCommand : ICommand
{
    private Player_Movement player_Movement;

    public CrouchCommand(Player_Movement player_Movement)
    {
        this.player_Movement = player_Movement;
    }

    public void Execute()
    {
        if (player_Movement.isCrouched)
        {
            player_Movement.StopCrouch();
        }
        else
        {
            player_Movement.StartCrouch();
        }
    }
}
