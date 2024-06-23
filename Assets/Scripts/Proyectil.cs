using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
   
        if (collision.gameObject.CompareTag("Enemigo"))
        {
         
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("DisparoEnemigo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }

    
}

