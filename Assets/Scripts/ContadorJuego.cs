using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public Text EnemigosRestantestxt;
    private int enemigosRestantes; // Cantidad de enemigos restantes
    void Start()
    {
        
        enemigosRestantes = GameObject.FindGameObjectsWithTag("Enemigo").Length;
        ActualizarTextoEnemigosRestantes();
    }

    public void EnemigoDestruido()
    {
        
        enemigosRestantes--;
        ActualizarTextoEnemigosRestantes();

      
        if (enemigosRestantes <= 0)
        {
           SceneManager.LoadScene("EscenaVictoria");
        }
    }

    void ActualizarTextoEnemigosRestantes()
    {
        EnemigosRestantestxt.text = "Enemigos Restantes: " + enemigosRestantes;
    }
}

