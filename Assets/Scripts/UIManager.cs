using TMPro;
using UnityEngine;

public class UIManeger : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private TextMeshProUGUI gameOverTimeText;
    [SerializeField] private TextMeshProUGUI victoryTimeText;

    private bool alreadyShown;

    void Update()
    {
        if (alreadyShown) return;

        if (CenaGameOver.GameEnded)
        {
            alreadyShown = true;
            CenaGameOver.FinishRun();

            if (CenaGameOver.HasWon)
            {
                victoryPanel.SetActive(true);
                AudioManager.Instance.PlayVictorySound();
                if (victoryTimeText != null)
                    victoryTimeText.text = $"Tempo: {CenaGameOver.FormatTime(CenaGameOver.FinalTime)}";
            }
            else if (CenaGameOver.HasLost)
            {
                gameOverPanel.SetActive(true);
                AudioManager.Instance.PlayGameOverSound();
                if (gameOverTimeText != null)
                    gameOverTimeText.text = $"Tempo: {CenaGameOver.FormatTime(CenaGameOver.FinalTime)}";
            }

            Time.timeScale = 0f;
        }
    }
}