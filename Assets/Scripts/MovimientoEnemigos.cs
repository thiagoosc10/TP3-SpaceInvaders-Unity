using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour
{
    public float velocidadHorizontal = 2.0f; // Velocidad de movimiento horizontal
    public float distanciaBajada = 0.5f; // Distancia que bajan los enemigos en cada cambio de dirección
    public float limiteIzquierdo = -10.0f; // Límite izquierdo del movimiento
    public float limiteDerecho = 10.0f; // Límite derecho del movimiento
    public int maxBajadas = 3; // Número máximo de bajadas antes de detenerse

    private bool moviendoDerecha = true; // Indica si los enemigos se mueven hacia la derecha
    private float tiempoDesdeUltimaBajada = 0.0f; // Tiempo transcurrido desde la última bajada
    public float tiempoParaBajar = 1.0f; // Tiempo cada cuanto bajan los enemigos
    private int contadorBajadas = 0; // Contador de cuántas veces han bajado

    void Update()
    {
        // Solo mover los enemigos si no han alcanzado el límite de bajadas
        if (contadorBajadas < maxBajadas)
        {
            // Mover enemigos horizontalmente
            if (moviendoDerecha)
            {
                transform.position += Vector3.right * velocidadHorizontal * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * velocidadHorizontal * Time.deltaTime;
            }

            // Verificar si los enemigos alcanzaron el límite del movimiento horizontal
            if (transform.position.x > limiteDerecho && moviendoDerecha)
            {
                Bajarse();
            }
            else if (transform.position.x < limiteIzquierdo && !moviendoDerecha)
            {
                Bajarse();
            }

            // Verificar si es tiempo de bajar los enemigos
            tiempoDesdeUltimaBajada += Time.deltaTime;
            if (tiempoDesdeUltimaBajada >= tiempoParaBajar)
            {
                Bajarse();
                tiempoDesdeUltimaBajada = 0.0f;
            }
        }
    }

    void Bajarse()
    {
        // Bajar a todos los enemigos
        transform.position += Vector3.down * distanciaBajada;

        // Cambiar la dirección de movimiento horizontal
        moviendoDerecha = !moviendoDerecha;

        // Incrementar el contador de bajadas
        contadorBajadas++;
    }
}
