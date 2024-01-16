using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    #region Variables

    public float money;

    public event Action OnMoneyChanged;

    public static Wallet i { get; private set; }

    #endregion

    #region Methods
    private void Awake()
    {
        i = this;
    }
    public void AddMoney(float amount)
    {
        money += amount;
        OnMoneyChanged?.Invoke();
    }

    public void TakeMoney(float amount)
    {
        money -= amount;
        OnMoneyChanged?.Invoke();
    }

    public float Money => money;

    #endregion
}
