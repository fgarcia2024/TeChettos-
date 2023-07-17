using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que representa una inteligencia artificial básica para un enemigo.
/// </summary>
public class IA_Basica : MonoBehaviour
{
    /// <summary>
    /// Animator utilizado para controlar las animaciones.
    /// </summary>
    public Animator animator;

    /// <summary>
    /// SpriteRenderer utilizado para controlar el sprite del enemigo.
    /// </summary>
    public SpriteRenderer spriteRenderer;

    /// <summary>
    /// Velocidad de movimiento del enemigo.
    /// </summary>
    public float speed = 1;

    private float waitTime;

    /// <summary>
    /// Puntos de movimiento para el enemigo.
    /// </summary>
    public Transform[] moveSpots;

    /// <summary>
    /// Tiempo de espera inicial.
    /// </summary>
    public float starWaitTime = 3;

    private int i = 0;

    private Vector2 actualPos;

    /// <summary>
    /// Método invocado cuando este objeto colisiona con otro Collider2D.
    /// Si la colisión es con un objeto de etiqueta "Player", se llama a la función PlayerDamaged() del script Revivir asociado al objeto colisionado.
    /// </summary>
    /// <param name="collision">El Collider2D con el que colisionó este objeto.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<Revivir>().PlayerDamaged();
        }
    }

    /// <summary>
/// Método invocado al inicio del objeto.
/// Establece el tiempo de espera inicial.
/// </summary>
void Start()
{
    waitTime = starWaitTime;
}

/// <summary>
/// Método invocado en cada fotograma.
/// Inicia una coroutine para comprobar si el enemigo se está moviendo y actualiza su posición.
/// </summary>
void Update()
{
    StartCoroutine(CheckEnemyMoving());
    transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

    if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
    {
        if (waitTime < 0)
        {
            if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
            waitTime = starWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}


    /// <summary>
    /// Coroutine para comprobar si el enemigo se está moviendo y actualizar las animaciones en consecuencia.
    /// </summary>
    IEnumerator CheckEnemyMoving()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > actualPos.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x < actualPos.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Idle", false);
        }

        if (transform.position.x == actualPos.x)
        {
            animator.SetBool("Idle", true);
        }
    }

}