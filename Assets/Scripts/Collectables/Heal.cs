using UnityEngine;
using System;

public class Heal : MonoBehaviour
{
    [SerializeField] private int _healValue = 1;

    public event Action<Heal> Collected;

    public int HealValue => _healValue;

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}
