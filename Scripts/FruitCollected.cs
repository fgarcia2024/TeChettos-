using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Clase que maneja la recolección de frutas por el jugador.
/// </summary>
public class FruitCollected : MonoBehaviour
{
    public AudioSource CoinMusic;
    /// <summary>
    /// Objeto de puntos utilizado para agregar los puntos obtenidos al jugador.
    /// </summary>
    public GameObject ObjPuntos;

    /// <summary>
    /// Puntos obtenidos al recolectar la fruta.
    /// </summary>
    public float PuntosOptenidos;

    void Start()
    {
        CoinMusic = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Método invocado cuando este objeto colisiona con otro Collider2D.
    /// Si la colisión es con un objeto de etiqueta "Player", se incrementa la puntuación del jugador y se destruye este objeto.
    /// </summary>
    /// <param name="collision">El Collider2D con el que colisionó este objeto.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ObjPuntos.GetComponent<Puntos>().puntos += PuntosOptenidos;
            CoinMusic.Play();

            // Introduce a delay before destroying the game object
            StartCoroutine(DestroyCoinWithDelay());
        }
    }

    IEnumerator DestroyCoinWithDelay()
    {
        yield return new WaitForSeconds(0.3f); // Adjust the delay time as needed

        Destroy(gameObject);
    }
}
