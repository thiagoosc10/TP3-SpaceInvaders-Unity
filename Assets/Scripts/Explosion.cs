using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float tiempoDeVida = 1.0f; // Tiempo que la explosión permanece en la escena

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }
}

