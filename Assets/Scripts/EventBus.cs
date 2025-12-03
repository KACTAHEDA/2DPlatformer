using System;

public static class EventBus
{
    public static Action CollectCoin;
    public static Action Jump;
    public static Action Damage;
    public static Action<bool> IsWalk;
    public static Action IsDead;
    public static Action LevelComplete;

    public static void CoinCollected()
    {
        CollectCoin?.Invoke();
    }

    public static void PlayerJump()
    {
        Jump?.Invoke();
    }

    public static void PlayerWalk(bool isWalking)
    {
        IsWalk?.Invoke(isWalking);
    }

    public static void TakeDamage()
    {
        Damage?.Invoke();
    }

    public static void Die()
    {
        IsDead?.Invoke();
    }

    public static void CompleteLevel()
    {
        LevelComplete.Invoke();
    }
}
