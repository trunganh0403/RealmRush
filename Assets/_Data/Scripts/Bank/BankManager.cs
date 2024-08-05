using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : GameMonoBehaviour
{
    private static BankManager instance;
    public static BankManager Instance { get => instance; }

    [SerializeField] protected int startingBalance = 15;
    [SerializeField] protected int currentBalance;
    public int CurrentBalance => currentBalance;

    protected override void Awake()
    {
        base.Awake();
        if (BankManager.instance != null) Debug.LogError("Only 1 BankManager allow to exist");
        BankManager.instance = this;

        currentBalance = startingBalance;
    }
    public virtual void Deposit(int amount)
    {
        if (amount <= 0) return;
        currentBalance += amount;
    }

    public virtual void Withdraw(int amount)
    {
        if (currentBalance <= 0) return;
        if (amount <= 0) return;
        currentBalance -= amount;
    }
}
