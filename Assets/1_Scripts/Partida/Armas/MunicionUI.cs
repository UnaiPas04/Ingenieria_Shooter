using UnityEngine;
using TMPro;

public class MunicionUI : MonoBehaviour
{
    public TextMeshProUGUI ammoText; // Referencia al texto en la UI
    public ArmaJugador playerWeapon; // Referencia al script del arma del jugador

    void Update()
    {
        if (playerWeapon != null && playerWeapon.propiedadesArmaEquipada != null)
        {
            // Obtén los valores de balas actuales y máxima
            float currentBullets = playerWeapon.propiedadesArmaEquipada.NumeroBalas;
            int maxBullets = playerWeapon.propiedadesGenericasArmaEquipada.NumeroBalasMax;

            // Actualiza el texto
            ammoText.text = $"{currentBullets} / {maxBullets}";
        }
    }
}
