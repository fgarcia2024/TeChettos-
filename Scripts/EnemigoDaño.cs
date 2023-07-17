using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que maneja el daño recibido por el enemigo.
/// </summary>
public class EnemigoDaño : MonoBehaviour
{

    /// <summary>
    /// Vida actual del enemigo.
    /// </summary>
    public float vida;
    /// <summary>
    /// Animator utilizado para controlar las animaciones.
    /// </summary>
    private Animator animator;
    /// <summary>
    /// Obtiene el componente Animator asociado a este objeto.
    /// </summary>
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    /// <summary>
    /// Reduce la vida del enemigo por una cantidad específica.
    /// </summary>
    /// <param name="daño">Cantidad de daño a aplicar.</param>
    public void TomarDaño(float daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            Muerte();

        }
    }

    /// <summary>
    /// Maneja las acciones a realizar cuando el enemigo muere.
    /// </summary>
    private void Muerte()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(gameObject, 0.5f);

    }

    /// <summary>
    /// Método invocado cuando este objeto colisiona con otro objeto en 2D.
    /// </summary>
    /// <param name="other">La información de colisión del otro objeto.</param>
    public void OnCollisionEnter2D(Collision2D other)
    {
        // Obtiene el componente CombatePlayer del objeto colisionado y llama al método TomarDaño con valores específicos.
        // El primer parámetro es la cantidad de daño (3 en este caso).
        // El segundo parámetro es la normal de contacto de la colisión para determinar la dirección del rebote.
        other.gameObject.GetComponent<CombatePlayer>().TomarDaño(3, other.GetContact(0).normal);
    }

}