using UnityEngine;

public static class CenaGameOver
{
    private static int collectableCount;
    private static int playerLives;

    public static bool gameOver
    {
        get { return playerLives <= 0; }
    }

    public static int Lives
    {
        get { return playerLives; }
    }

    public static void Init()
    {
        collectableCount = 8;
        playerLives = 5;
    }

    public static void Collect()
    {
        collectableCount--;
    }

    public static void TakeDamage(int damage)
    {
        playerLives -= damage;

        if (playerLives < 0)
            playerLives = 0;
    }
}