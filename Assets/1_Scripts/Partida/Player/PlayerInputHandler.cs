using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

    [Header("Movement")]
    public Player_Movement player_Movement;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        ICommand moveCommand = new MoveCommand(player_Movement, x, z);
        moveCommand.Execute();

        if(Input.GetKeyDown(player_Movement.jumpKey))
        {
            ICommand jumpCommand = new JumpCommand(player_Movement);
            jumpCommand.Execute();
        }

        if(Input.GetKeyDown(player_Movement.crouchKey) || Input.GetKeyUp(player_Movement.crouchKey))
        {
            ICommand crouchCommand = new CrouchCommand(player_Movement);
            crouchCommand.Execute();
        }

        if (Input.GetKeyDown(player_Movement.runKey) || Input.GetKeyUp(player_Movement.runKey))
        {
            ICommand runCommand = new RunCommand(player_Movement);
            runCommand.Execute();
        }
    }
}
