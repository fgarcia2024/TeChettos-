using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Clase que gestiona los paneles en el juego.
/// </summary>
public class PanelesManager : MonoBehaviour
{
     /// <summary>
    /// Panel que muestra cuand finaliza e juego.
    /// </summary>
    public GameObject PanelFinNivel;
    /// <summary>
    /// Variable publica que accede al componente audiosource.
    /// </summary>
    public AudioSource Mute;

    /// <summary>
    /// Panel de opciones del menú.
    /// </summary>
    public GameObject MenuOpciones;

    /// <summary>
    /// Panel de ajustes de sonido.
    /// </summary>
    public GameObject PanelSonido;
    /// <summary>
    /// Activa el panel de opciones del menú.
    /// </summary>
    public void MenuOpcion()
    {
        MenuOpciones.SetActive(true);
    }

    /// <summary>
    /// Activa el panel de ajustes de sonido y desactiva el panel de opciones del menú.
    /// </summary>
    public void ActivarPanelSonido()
    {
        PanelSonido.SetActive(true);
        MenuOpciones.SetActive(false);
    }

    /// <summary>
    /// Desactiva el panel de ajustes de sonido y activa el panel de opciones del menú.
    /// </summary>
    public void DesactivarPanelSonido()
    {
        PanelSonido.SetActive(false);
        MenuOpciones.SetActive(true);
    }
    /// <summary>
    /// Reproduce el sonido.
    /// </summary>
    public void SonidoOn()
    {
        // Reproduce el sonido usando el objeto Mute.
        Mute.Play();
    }

    /// <summary>
    /// Detiene el sonido.
    /// </summary>
    public void SonidoOF()
    {
        // Detiene el sonido usando el objeto Mute.
        Mute.Stop();
    }

    /// <summary>
    /// Desactiva el panel de opciones del menú.
    /// </summary>
    public void Regresar()
    {
        MenuOpciones.SetActive(false);
    }

    /// <summary>
    /// Carga la escena del menú principal.
    /// </summary>
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Sale del juego.
    /// </summary>
    public void SalirDelJuego()
    {
        Application.Quit();
    }
    /// <summary>
    /// Método invocado cuando este objeto colisiona con otro Collider2D.
    /// </summary>
    /// <param name="collision">El Collider2D con el que colisionó este objeto.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto colisionado tiene la etiqueta "Player".
        if (collision.gameObject.CompareTag("Player"))
        {
            // Activa el GameObject PanelFinNivel para mostrar el panel de fin de nivel.
            PanelFinNivel.gameObject.SetActive(true);
        }
    }

}