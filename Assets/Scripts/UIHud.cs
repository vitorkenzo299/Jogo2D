using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHud : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private TextMeshProUGUI collectiblesText;
    [SerializeField] private TextMeshProUGUI timerText;

    void Update()
    {
        int lives = CenaGameOver.Lives;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < lives;
        }

        if (collectiblesText != null)
        {
            collectiblesText.text = $"Coletados: {CenaGameOver.CollectedCollectables}/{CenaGameOver.TotalCollectables}";
        }

        if (timerText != null)
        {
            timerText.text = $"Tempo: {CenaGameOver.FormatTime(CenaGameOver.ElapsedTime)}";
        }
    }
}