using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void IniciaJogo()
    {
        Time.timeScale = 1f;
        CenaGameOver.Init();
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}