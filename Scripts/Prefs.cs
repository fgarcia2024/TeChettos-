using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;
/// <summary>
/// Guarda las preferencias del jugador.
/// </summary>
public class Prefs : MonoBehaviour
{
    /// <summary>
    /// Campo de entrada de texto para el nombre del usuario.
    /// </summary>
    public InputField txtnombre;

    /// <summary>
    /// Botón para guardar los datos del usuario.
    /// </summary>
    public Button btnSave;

    /// <summary>
    /// Botón para obtener los datos del usuario.
    /// </summary>
    public Button btnGetData;

    /// <summary>
    /// Teclado virtual utilizado para la entrada de texto.
    /// </summary>
    private TouchScreenKeyboard keyboard;

    /// <summary>
    /// Configura el evento para escuchar cambios en el campo de entrada de texto al iniciar.
    /// </summary>
    void Start()
    {
        txtnombre.onValueChanged.AddListener(OnInputFieldValueChanged);
    }

    /// <summary>
    /// Guarda el nombre del usuario en PlayerPrefs.
    /// </summary>
    public void SavePref()
    {
        string name = txtnombre.text;
        PlayerPrefs.SetString("Usuario", name);
    }

    /// <summary>
    /// Obtiene los datos del usuario y carga la escena "Inicio".
    /// </summary>
    public void GetPref()
    {
        Debug.Log(PlayerPrefs.GetString("Usuario"));
        SceneManager.LoadScene("Inicio");
    }

    /// <summary>
    /// Elimina el nombre del usuario de PlayerPrefs.
    /// </summary>
    public void DeletePlayerName()
    {
        PlayerPrefs.DeleteKey("Usuario");
    }

    /// <summary>
    /// Maneja el evento cuando el valor del campo de entrada de texto cambia.
    /// </summary>
    /// <param name="text">El nuevo valor del campo de entrada de texto.</param>
    private void OnInputFieldValueChanged(string text)
    {
        if (txtnombre.isFocused)
        {
            keyboard = TouchScreenKeyboard.Open(text);
        }
        else
        {
            if (keyboard != null && keyboard.active)
            {
                keyboard.active = false;
            }
        }
    }
}
