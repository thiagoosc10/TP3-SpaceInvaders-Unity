using UnityEngine;

public class DestruirDisparoEnemigoFuera : MonoBehaviour
{
    void OnBecameInvisible()
    {
        // Destruir el proyectil cuando ya no es visible por ninguna cámara
        Destroy(gameObject);
    }
}
