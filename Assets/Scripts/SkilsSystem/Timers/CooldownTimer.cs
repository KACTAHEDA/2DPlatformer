using UnityEngine;

public class CooldownTimer : Timer
{
    public bool IsReady => IsRuning == false;
}
