using UnityEngine;
using UnityEngine.SceneManagement;

public class DisparoEnemigo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);         
            Destroy(gameObject);
            SceneManager.LoadScene("EscenaGameOver");
            SoundManager.instance.PlayMuerteJugador();
        }
    
        else if (!other.CompareTag("Enemigo"))
        {
            Destroy(gameObject);
        }
        
    }
}




