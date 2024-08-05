using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldOverTime : DelayedSpawner
{
    [SerializeField] protected int goldByTime = 1;

    protected override void FixedUpdate()
    {
        CheckRandomStatus();
        base.FixedUpdate();
    }
    protected override void ResetValue()
    {
        this.timeDelay = 2f;
    }
  
    protected override void SpawnObj()
    {
        BankManager.Instance.Deposit(goldByTime);
    }

    protected virtual void CheckRandomStatus()
    {
        if(CarSpawner.Instance.SpawnedCount >=1)
        {
            IsDelay = true;
        } 

        else
        {
            IsDelay=false;
        }    
            
    }    
}


