using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que maneja el daño al jugador.
/// </summary>
public class DañoPlayer : MonoBehaviour
{
    /// <summary>
    /// Método invocado cuando este objeto colisiona con otro Collider2D.
    /// </summary>
    /// <param name="collision">El Collider2D con el que colisionó este objeto.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        { 
            collision.transform.GetComponent<Revivir>().PlayerDamaged();
        }
    }
}                                       