using UnityEngine;

public static class CenaGameOver
{   
    private static int collectableCount;

    public static bool gameOver
    {
        get { return collectableCount <= 0; }
    }
    
    public static void Init()
    {
        collectableCount = 4;
    }

    public static void Collect()
    {
        collectableCount--;
    }
}