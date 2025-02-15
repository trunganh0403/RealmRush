using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : GameMonoBehaviour
{
    private void FixedUpdate()
    {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObj();
    }

    public virtual void DespawnObj()
    {
        // For override
    }
    protected abstract bool CanDespawn();

}