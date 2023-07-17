using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clase que gestiona la carga de datos y muestra de texto de bienvenida al jugador.
/// </summary>
public class SaveData : MonoBehaviour
{
    /// <summary>
    /// Nombre del jugador cargado.
    /// </summary>
    public static string loadedPlayername;

    /// <summary>
    /// Referencia al objeto de texto que muestra el mensaje de bienvenida.
    /// </summary>
    public Text PlayerNameText;

    /// <summary>
    /// Método que se ejecuta al iniciar el objeto.
    /// </summary>
    void Start()
    {
        // Cargar el nombre del jugador desde PlayerPrefs.
        loadedPlayername = PlayerPrefs.GetString("Usuario");

        // Mostrar el mensaje de bienvenida con el nombre del jugador.
        PlayerNameText.text = "¡Hola " + loadedPlayername + " ,bienvenido al videojuego DelCastellano, espero que lo disfrutes!";
    }
}
