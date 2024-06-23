using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador : MonoBehaviour
{
    public GameObject prefabDisparo; // Referencia al prefab del disparo
    public Transform puntoDeDisparo;   // Punto desde donde se disparará el disparo
    public float velocidadDisparoJugador = 10f; // Velocidad del disparo

    private Vector2 movimiento;

    public void OnMove(InputValue input)
    {
        movimiento = input.Get<Vector2>();
    }

    public void OnFire()
    {
        Disparar();
    }

    void Update()
    {
        Mover();
    }

    void Mover()
    {
        transform.position = new Vector3(
            transform.position.x + movimiento.x * Time.deltaTime,
            transform.position.y + movimiento.y * Time.deltaTime,
            0
        );
    }

    void Disparar()
    {
        // Verificar si el prefabDisparo no es null antes de instanciarlo
        if (prefabDisparo != null)
        {
            GameObject proyectil = Instantiate(prefabDisparo, puntoDeDisparo.position, Quaternion.identity);
            Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.up * velocidadDisparoJugador; 
            }

            SoundManager.instance.PlayDisparoJugador();
        }
        else
        {
            Debug.LogError("El prefab del disparo no está asignado.");
        }
    }
}


