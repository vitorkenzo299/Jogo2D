using UnityEngine;

public class UIManeger : MonoBehaviour
{
    public GameObject endGamePanel;

    void Update()
    {
        if (CenaGameOver.gameOver)
        {
            endGamePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}