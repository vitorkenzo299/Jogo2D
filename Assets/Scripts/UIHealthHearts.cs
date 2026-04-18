using UnityEngine;
using UnityEngine.UI;

public class UIHealthHearts : MonoBehaviour
{
    [SerializeField] private Image[] hearts;

    void Update()
    {
        int lives = CenaGameOver.Lives;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < lives;
        }
    }
}