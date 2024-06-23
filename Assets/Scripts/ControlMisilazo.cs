using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMisilazo : MonoBehaviour
{
    public GameObject prefabMisilazo;
    public Transform puntoDeDisparo;
    public float velocidadMisilazo = 5f;
    public float tiempoEsperaMisilazo = 5f;
    public float duracionTemblor = 0.3f;
    public float magnitudTemblor = 0.2f;
    private bool puedeDisparar = true;

    private void Update()
    {
        if (puedeDisparar && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            Vector3 direccion = (mousePos - transform.position).normalized;

            DispararMisilazo(direccion);
            StartCoroutine(TemporizadorMisilazo());
        }
    }

    private void DispararMisilazo(Vector3 direccion)
    {
        GameObject misilazo = Instantiate(prefabMisilazo, puntoDeDisparo.position, Quaternion.identity);
        Rigidbody2D rb = misilazo.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direccion * velocidadMisilazo;
        }
    }

    private IEnumerator TemporizadorMisilazo()
    {
        puedeDisparar = false;
        yield return new WaitForSeconds(tiempoEsperaMisilazo);
        puedeDisparar = true;
    }

}

