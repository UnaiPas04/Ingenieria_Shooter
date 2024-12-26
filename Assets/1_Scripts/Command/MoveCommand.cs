using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Player_Movement playerMovement;
    private float x, z;

    public MoveCommand(Player_Movement playerMovement, float x, float z)
    {
        this.playerMovement = playerMovement;
        this.x = x;
        this.z = z;
    }

    public void Execute()
    {
        playerMovement.Move(x, z);
    }
}
