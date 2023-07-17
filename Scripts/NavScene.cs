using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que maneja el cambio de escenas.
/// </summary>
public class NavScene : MonoBehaviour
{
    
    /// <summary>
    /// Cambia a la escena especificada.
    /// </summary>
    /// <param name="scene">Nombre de la escena a la que se quiere cambiar.</param>
    public void CambioScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}