using System;
using UnityEngine;

public static class GlobalEventManager
{
    public static Action OnEnemyKillled;

    public static Action OnWin;

    public static Action OnLoss;

    public static void SendEnemyKilled()
    {
        OnEnemyKillled?.Invoke();
    }

    public static void SendWin()
    {
        OnWin?.Invoke();
    }

    public static void SendLoss()
    {
        OnLoss?.Invoke();
    }
}
