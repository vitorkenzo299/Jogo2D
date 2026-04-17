using UnityEngine;

public class UIManeger : MonoBehaviour
{
    public GameObject endGamePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CenaGameOver.gameOver)
        {
            endGamePanel.SetActive(true);
        }
    }
}
