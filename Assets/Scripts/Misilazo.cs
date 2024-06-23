using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misilazo : MonoBehaviour
{
    public float velocidad = 5.0f; // Velocidad del misilazo (más lento que el misil normal)
    public float radioExplosion = 2.0f; // Radio de la explosión
    public GameObject efectoExplosion; // Prefab del efecto de la explosión
    public float duracionShake = 0.3f; // Duración del screen shake
    public float magnitudShake = 0.1f; // Magnitud del screen shake

    private Vector3 direccion;

    public void Disparar(Vector3 dir)
    {
        direccion = dir.normalized;
    }

    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.instance.PlayExplosion();
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("Colisión con enemigo");

            // Crear el efecto de la explosión
            Instantiate(efectoExplosion, transform.position, Quaternion.identity);

            // Detectar enemigos en el radio de la explosión
            Collider2D[] enemigosAlcanzados = Physics2D.OverlapCircleAll(transform.position, radioExplosion);
            foreach (Collider2D enemigo in enemigosAlcanzados)
            {
                if (enemigo.CompareTag("Enemigo"))
                {
                    Debug.Log("Destruyendo enemigo: " + enemigo.gameObject.name);
                    Destroy(enemigo.gameObject);
                }
            }

            // Destruir el misilazo
            Destroy(gameObject);
        }
        
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar el radio de la explosión en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioExplosion);
    }
}




