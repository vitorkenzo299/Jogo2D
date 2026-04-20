using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void IniciaJogo()
    {
        Time.timeScale = 1f;
        CenaGameOver.Init();
        SceneManager.LoadScene("Jogo");
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}