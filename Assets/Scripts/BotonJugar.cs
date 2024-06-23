using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJugar : MonoBehaviour
{
    public string nombreEscena;
    public void Jugar()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
