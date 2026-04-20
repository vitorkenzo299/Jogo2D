using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private void Update()
    {
        CenaGameOver.AddTime(Time.deltaTime);
    }
}