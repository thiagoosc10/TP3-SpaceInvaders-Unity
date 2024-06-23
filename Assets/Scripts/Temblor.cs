using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Temblor : MonoBehaviour
{
    public float tiempo = 1f;
    private void Start()
    {
        GetComponent<SpriteRenderer>()
            .DOFade(0f, tiempo)
            .OnComplete(() => Destroy(gameObject));

        Camara.Instancia.ScreenShake();
    }
}
