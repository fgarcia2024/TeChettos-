using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que maneja el combate del jugador.
/// </summary>
public class CombatePlayer : MonoBehaviour
{
    /// <summary>
    /// Referencia al componente MovimientosPlayer que controla el movimiento del jugador.
    /// </summary>
    private MovimientosPlayer movimientosjugador;

    /// <summary>
    /// Tiempo de pérdida de control del jugador después de recibir daño.
    /// </summary>
    [SerializeField]
    private float perdidaControl;

    /// <summary>
    /// Transform del punto de control del golpe.
    /// </summary>
    public Transform ControladoGolpe;

    /// <summary>
    /// Radio de alcance del golpe.
    /// </summary>
    public float radioGolpe;

    /// <summary>
    /// Daño infligido por el golpe.
    /// </summary>
    public float dañoGolpe;

    /// <summary>
    /// Tiempo mínimo entre cada ataque.
    /// </summary>
    public float tiempoEntreAtaque;

    /// <summary>
    /// Animator utilizado para controlar las animaciones.
    /// </summary>
    private Animator animator;

    /// <summary>
    /// Tiempo restante hasta el siguiente ataque.
    /// </summary>
    private float tiempoSiguienteAtaque;

    /// <summary>
    /// Método invocado al inicio del objeto.
    /// Obtiene el componente Animator asociado a este objeto.
    /// </summary>
    private void Start()
    {
        movimientosjugador = GetComponent<MovimientosPlayer>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Método invocado en cada fotograma.
    /// Controla el tiempo restante hasta el siguiente ataque y realiza un ataque si se presiona la tecla "e".
    /// </summary>
    private void Update()
    {
        // if (tiempoSiguienteAtaque > 0)
        // {
        //     tiempoSiguienteAtaque -= Time.deltaTime;
        // }

        if (Input.GetKey("e"))
        {
            Ataque();
            // tiempoSiguienteAtaque = tiempoEntreAtaque;
        }
    }


    /// <summary>
    /// Realiza un ataque golpeando a los enemigos dentro del radio de golpe.
    /// </summary>
    public void Ataque()
    {
        animator.SetTrigger("Ataque");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(ControladoGolpe.position, radioGolpe);
        foreach (Collider2D collision in objetos)
        {
            if (collision.CompareTag("Enemigo"))
            {
                collision.transform.GetComponent<EnemigoDaño>().TomarDaño(dañoGolpe);
            }
        }
    }

    /// <summary>
    /// Dibuja un gizmo en el editor para representar el área de golpeo.
    /// </summary>
    private void OnDrawGizmo()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(ControladoGolpe.position, radioGolpe);
    }

    /// <summary>
    /// Método que se llama cuando el jugador recibe daño.
    /// </summary>
    /// <param name="daño">Cantidad de daño recibido.</param>
    /// <param name="posicion">Posición desde donde se recibió el daño.</param>
    public void TomarDaño(float daño, Vector2 posicion)
    {
        StartCoroutine(PerderControl()); // Inicia la corrutina para perder el control del jugador.
        movimientosjugador.Rebote(posicion); // Aplica un rebote al jugador en la posición especificada.
    }

    /// <summary>
    /// Corrutina que hace que el jugador pierda el control durante un tiempo determinado.
    /// </summary>
    /// <returns>Espera hasta que se haya perdido el control del jugador.</returns>
    private IEnumerator PerderControl()
    {
        movimientosjugador.sePuedeMover = false; // Desactiva el movimiento del jugador.
        yield return new WaitForSeconds(perdidaControl); // Espera por un tiempo determinado.
        movimientosjugador.sePuedeMover = true; // Reactiva el movimiento del jugador.
    }

}