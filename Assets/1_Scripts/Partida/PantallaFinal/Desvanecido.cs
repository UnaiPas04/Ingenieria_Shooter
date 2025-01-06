using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro; // Importa TextMeshPro

public class Desvanecido : MonoBehaviour
{
    public Image fadeImage; // Imagen negra para el desvanecido
    public TMP_Text mensajeTexto; // Texto que aparecer� en pantalla
    public float fadeDuration = 2f; // Duraci�n del desvanecido
    public float mensajeDuration = 3f; // Duraci�n del mensaje en pantalla
    public string nombreEscenaDestino; // Nombre de la escena a cargar

    public void IniciarDesvanecido()
    {
        fadeImage.gameObject.SetActive(true); // Aseg�rate de que la imagen est� activa
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        // Desvanecer a negro
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;

        // Mostrar el mensaje
        if (mensajeTexto != null)
        {
            mensajeTexto.gameObject.SetActive(true); // Activa el texto
            yield return new WaitForSeconds(mensajeDuration); // Espera el tiempo del mensaje
            mensajeTexto.gameObject.SetActive(false); // Opcional: Oculta el texto despu�s
        }

        // Activar el cursor antes de cargar el men�
        Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
        Cursor.visible = true; // Muestra el cursor

        // Cargar la nueva escena
        SceneManager.LoadScene(nombreEscenaDestino);
    }

}
