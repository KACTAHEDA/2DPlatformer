using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Coins { get; private set; }

    public event Action ValueChanged;

    public void AddCoin()
    {
        Coins++;

        ValueChanged?.Invoke();
    }
}
