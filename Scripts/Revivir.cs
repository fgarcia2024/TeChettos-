using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


/// <summary>
/// Clase que gestiona la vida del jugador y la funcionalidad de revivir.
/// </summary>
public class Revivir : MonoBehaviour
{
    /// <summary>
    /// Cantidad de vidas del jugador.
    /// </summary>
    private int vidas;

    /// <summary>
    /// Panel que se muestra cuando el jugador pierde todas las vidas.
    /// </summary>
    public GameObject PanelGameOver;

    /// <summary>
    /// Array que contiene los corazones de vida del jugador.
    /// </summary>
    public GameObject[] corazon;

    /// <summary>
    /// Método que se ejecuta al iniciar el objeto.
    /// </summary>
    void Start()
    {
        vidas = corazon.Length;
    }

    /// <summary>
    /// Método que se ejecuta en cada fotograma.
    /// </summary>
    void Update()
    {
        if (vidas < 1)
        {
            // Si el jugador no tiene vidas, destruir el primer corazón y mostrar el panel de Game Over.
            Destroy(corazon[0].gameObject);
            PanelGameOver.SetActive(true);
        }
        else if (vidas < 2)
        {
            // Si el jugador tiene menos de 2 vidas, destruir el segundo corazón.
            Destroy(corazon[1].gameObject);
        }
        else if (vidas < 3)
        {
            // Si el jugador tiene menos de 3 vidas, destruir el tercer corazón.
            Destroy(corazon[2].gameObject);
        }
    }

    /// <summary>
    /// Método llamado cuando el jugador recibe daño.
    /// </summary>
    public void PlayerDamaged()
    {
        vidas--;
    }

    /// <summary>
    /// Método llamado al presionar el botón de continuar en el panel de Game Over.
    /// </summary>
    public void Continuar()
    {
        // Desactivar el panel de Game Over y cargar de nuevo la escena actual.
        PanelGameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
