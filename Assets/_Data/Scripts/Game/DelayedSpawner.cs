using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class DelayedSpawner : GameMonoBehaviour
{
    [SerializeField] private bool isDelay;
    [SerializeField] protected float timeDelay = 0.2f;
    [SerializeField] protected float currenTime = 0f;

    public bool IsDelay { get => isDelay; set => isDelay=value; }

    protected virtual void FixedUpdate()
    {
        this.SpawnWithDelay();
    }

    protected virtual void SpawnWithDelay()
    {
        if (!isDelay) return;

        currenTime += Time.fixedDeltaTime;
        if (currenTime < timeDelay) return;
        currenTime = 0f;

        this.SpawnObj();
    }

    protected virtual void SpawnObj()
    {
       //For Ovr
    }    
}
