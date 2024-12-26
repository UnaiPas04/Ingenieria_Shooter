using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    private Player_Movement player_Movement;

    public JumpCommand(Player_Movement player_Movement)
    {
        this.player_Movement = player_Movement;
    }

    public void Execute()
    {
        player_Movement.Jump();
    }
}
