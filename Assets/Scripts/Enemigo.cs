using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject prefabDisparoEnemigo; // Prefab del disparo del enemigo
    public Transform puntoDeDisparo; // Punto desde donde se dispara
    public float tiempoMinEntreDisparos = 1f; // Tiempo mínimo entre cada disparo
    public float tiempoMaxEntreDisparos = 6f; // Tiempo máximo entre cada disparo
    private float tiempoProximoDisparo; // Tiempo del próximo disparo
    private GameController gameController;


    void Start()
    {
        tiempoProximoDisparo = Time.time + Random.Range(tiempoMinEntreDisparos, tiempoMaxEntreDisparos);
        // Encontrar el GameController en la escena
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
       
        if (Time.time >= tiempoProximoDisparo)
        {
            Disparar();
           
            tiempoProximoDisparo = Time.time + Random.Range(tiempoMinEntreDisparos, tiempoMaxEntreDisparos);
        }
    }

    void Disparar()
    {
        // Crear un disparo
        GameObject disparo = Instantiate(prefabDisparoEnemigo, puntoDeDisparo.position, Quaternion.identity);
        disparo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
         SoundManager.instance.PlayDisparoEnemigo();
    }

    void OnDestroy()
    {
        // Notifica al GameController cuando el enemigo es destruido
        if (gameController != null)
        {
            gameController.EnemigoDestruido();
        }
        SoundManager.instance.PlayDestruccionNave();
    }
}


