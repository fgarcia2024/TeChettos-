using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

/// <summary>
/// Clase que controla la navegación entre actividades y el diálogo en el juego.
/// </summary>
public class NavActividades : MonoBehaviour
{
    
    /// <summary>
    /// Panel de actividades.
    /// </summary>
    public GameObject PanelActividades;

    /// <summary>
    /// Panel de diálogo.
    /// </summary>
    public GameObject PanelDialogo;

    /// <summary>
    /// Panel de respuesta correcta.
    /// </summary>
    public GameObject PanelCorrecto;

    /// <summary>
    /// Panel de respuesta incorrecta.
    /// </summary>
    public GameObject PanelIncorrecto;

    /// <summary>
    /// Texto del diálogo.
    /// </summary>
    public TMP_Text dialogoText;

    /// <summary>
    /// Índice actual del diálogo.
    /// </summary>
    private int index;

    /// <summary>
    /// Tiempo de escritura de cada carácter en el diálogo.
    /// </summary>
    private float typingTime = 0.05f;

    /// <summary>
    /// Array de texto que contiene las líneas de diálogo.
    /// </summary>
    [SerializeField, TextArea(4, 6)] private string[] texto;

    /// <summary>
    /// Indica si se ha iniciado el diálogo.
    /// </summary>
    private bool DialogoStart;

    /// <summary>
    /// Indica si se puede abrir el diálogo.
    /// </summary>
    private bool abrir;




    /// <summary>
    /// Método invocado en cada fotograma.
    /// Comprueba si se debe abrir el diálogo o avanzar a la siguiente línea.
    /// </summary>
    void Update()
    {
        if (abrir && Input.GetButtonDown("Fire1"))
        {
            if (!DialogoStart)
            {
                ComenzarDialgo();
            }
            else if (dialogoText.text == texto[index])
            {
                SiguientesLineas();
            }
        }
    }

    /// <summary>
    /// Inicia el diálogo.
    /// </summary>
    public void ComenzarDialgo()
    {
        DialogoStart = true;
        PanelDialogo.SetActive(true);
        index = 0;
        StartCoroutine(MostrarDialogo());
    }

    /// <summary>
    /// Muestra las siguientes líneas de diálogo.
    /// </summary>
    private void SiguientesLineas()
    {
        index++;
        if (index < texto.Length)
        {
            StartCoroutine(MostrarDialogo());
        }
        else
        {
            DialogoStart = false;
        }
    }

    /// <summary>
    /// Muestra el diálogo letra por letra.
    /// </summary>
    public IEnumerator MostrarDialogo()
    {
        dialogoText.text = string.Empty;

        foreach (char ch in texto[index])
        {
            dialogoText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    /// <summary>
    /// Método invocado cuando este objeto colisiona con otro Collider2D.
    /// Activa el panel de actividades y diálogo.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            abrir = true;
            PanelActividades.gameObject.SetActive(true);
            PanelDialogo.gameObject.SetActive(true);
            PanelCorrecto.gameObject.SetActive(false);
            PanelIncorrecto.gameObject.SetActive(false);
            
        }
    }

    /// <summary>
    /// Desactiva el panel de actividades y diálogo.
    /// </summary>
    public void DesactivarPanel()
    {
        PanelActividades.gameObject.SetActive(false);
        PanelDialogo.gameObject.SetActive(false);
        PanelCorrecto.gameObject.SetActive(false);
        PanelIncorrecto.gameObject.SetActive(false);
    }

    /// <summary>
    /// Activa el panel de respuesta correcta.
    /// </summary>
    public void Correcto()
    {
        PanelActividades.gameObject.SetActive(false);
        PanelDialogo.gameObject.SetActive(false);
        PanelCorrecto.gameObject.SetActive(true);
        PanelIncorrecto.gameObject.SetActive(false);
    }

    /// <summary>
    /// Activa el panel de respuesta incorrecta.
    /// </summary>
    public void Icorrecto()
    {
        PanelActividades.gameObject.SetActive(false);
        PanelCorrecto.gameObject.SetActive(false);
        PanelDialogo.gameObject.SetActive(false);
        PanelIncorrecto.gameObject.SetActive(true);
    }
}