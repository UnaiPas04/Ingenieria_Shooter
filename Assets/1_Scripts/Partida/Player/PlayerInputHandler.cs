using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

    [Header("Movement")]
    public Player_Movement player_Movement;

    [Header("Weapons")]
    public ArmaJugador armaJugador;

    public AudioSource recargarAudio;

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

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ICommand switchToPistol = new ChangeWeaponCommand(armaJugador, 0);
            switchToPistol.Execute();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ICommand switchToShotgun = new ChangeWeaponCommand(armaJugador, 1);
            switchToShotgun.Execute();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ICommand switchToAutomatic = new ChangeWeaponCommand(armaJugador, 2);
            switchToAutomatic.Execute();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!armaJugador.isReloading())
            {
                recargarAudio.Play();
                ICommand reloadWeaponCommand = new ReloadCommand(armaJugador);
                reloadWeaponCommand.Execute();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!armaJugador.isReloading())
            {
                ICommand startShootingCommand = new StartShootingCommand(armaJugador);
                startShootingCommand.Execute();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            ICommand stopShootingCommand = new StopShootingCommand(armaJugador);
            stopShootingCommand.Execute();
        }
    }
}
