using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float delay = 1f;
    [SerializeField] protected float timer = 0f;

    protected override void OnEnable()
    {
        base.OnEnable();
        ResetTime();

    }
    protected virtual void ResetTime()
    {
        timer =0f;
    }
    protected override bool CanDespawn()
    {
        timer += Time.fixedDeltaTime;
        if (timer > delay) return true;
        return false;
    }

    public override void DespawnObj()
    {
        FXSpawner.Instance.Despawn(transform.parent.transform);
    }
}
