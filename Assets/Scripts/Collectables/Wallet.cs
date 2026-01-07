using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action ValueChanged;
    
    public int Coins { get; private set; }

    public void AddCoin()
    {
        Coins++;

        ValueChanged?.Invoke();
    }
}
