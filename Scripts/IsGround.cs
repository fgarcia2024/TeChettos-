using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que detecta si el objeto está en contacto con el suelo.
/// </summary>
public class IsGround : MonoBehaviour
{
   /// <summary>
    /// Indica si el objeto está en contacto con el suelo.
    /// </summary>
    public static bool isGround;

    /// <summary>
    /// Método invocado cuando este objeto colisiona con otro Collider2D.
    /// Establece la variable isGround en true cuando se produce la colisión.
    /// </summary>
    /// <param name="collision">El Collider2D con el que colisionó este objeto.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGround = true;
    }

    /// <summary>
    /// Método invocado cuando este objeto deja de colisionar con otro Collider2D.
    /// Establece la variable isGround en false cuando deja de haber colisión.
    /// </summary>
    /// <param name="collision">El Collider2D con el que dejó de colisionar este objeto.</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround = false;
    }
}
