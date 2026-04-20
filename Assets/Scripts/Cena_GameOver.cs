using UnityEngine;

public static class CenaGameOver
{
    private static int totalCollectables;
    private static int collectedCollectables;
    private static int playerLives;

    private static float elapsedTime;
    private static float finalTime;

    public static bool HasWon => collectedCollectables >= totalCollectables;
    public static bool HasLost => playerLives <= 0;
    public static bool GameEnded => HasWon || HasLost;

    public static int Lives => playerLives;
    public static int CollectedCollectables => collectedCollectables;
    public static int TotalCollectables => totalCollectables;

    public static float ElapsedTime => elapsedTime;
    public static float FinalTime => finalTime;

    public static void Init()
    {
        totalCollectables = 8;
        collectedCollectables = 0;
        playerLives = 5;

        elapsedTime = 0f;
        finalTime = 0f;
    }

    public static void AddTime(float deltaTime)
    {
        if (!GameEnded)
            elapsedTime += deltaTime;
    }

    public static void FinishRun()
    {
        finalTime = elapsedTime;
    }

    public static void Collect()
    {
        if (collectedCollectables < totalCollectables)
            collectedCollectables++;
    }

    public static void TakeDamage(int damage)
    {
        playerLives -= damage;

        if (playerLives < 0)
            playerLives = 0;
    }

    public static string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return $"{minutes:00}:{seconds:00}";
    }
}