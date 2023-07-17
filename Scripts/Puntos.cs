using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clase que gestiona la puntuación del juego.
/// </summary>
public class Puntos : MonoBehaviour
{
    /// <summary>
    /// Puntuación actual.
    /// </summary>
    public float puntos;

    /// <summary>
    /// Texto que muestra la puntuación actual.
    /// </summary>
    public Text textoPuntos;

    /// <summary>
    /// Texto que muestra el récord de puntuación.
    /// </summary>
    public Text textoRecordPuntos;

    /// <summary>
    /// Texto que muestra la puntuación total.
    /// </summary>
    public Text textoPuntosTotal;

    /// <summary>
    /// Método que se ejecuta al iniciar el objeto.
    /// </summary>
    void Start()
    {
        // Obtener el récord de puntuación guardado en PlayerPrefs y mostrarlo en el texto.
        textoRecordPuntos.text = PlayerPrefs.GetFloat("PuntajeRecord", 0).ToString();
    }

    /// <summary>
    /// Método que se ejecuta en cada fotograma.
    /// </summary>
    void Update()
    {
        // Actualizar el texto de la puntuación actual.
        textoPuntos.text = puntos.ToString();

        // Actualizar el texto de la puntuación total.
        textoPuntosTotal.text = puntos.ToString();

        if (puntos > PlayerPrefs.GetFloat("PuntajeRecord", 0))
        {
            // Si la puntuación actual es mayor que el récord, actualizar el récord y mostrarlo en el texto.
            PlayerPrefs.SetFloat("PuntajeRecord", puntos);
            textoRecordPuntos.text = puntos.ToString();
        }
    }
}
