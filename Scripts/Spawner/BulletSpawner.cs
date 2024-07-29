using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : ObjSpawner
{
    [SerializeField] private BallistaLookAtTager ballistaLookAtTager;

    [SerializeField] protected Transform ballistaTopMesh;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBallistaLookAtTager();
        this.LoadBallistaTopMesh();
    }

    protected virtual void LoadBallistaLookAtTager()
    {
        if (this.ballistaLookAtTager != null) return;
        this.ballistaLookAtTager = FindAnyObjectByType<BallistaLookAtTager>();
        Debug.LogWarning(transform.name + ": BallistaLookAtTager", gameObject);
    }

    protected virtual void LoadBallistaTopMesh()
    {
        if (this.ballistaTopMesh != null) return;
        this.ballistaTopMesh = transform.parent;
        Debug.LogWarning(transform.name + ": LoadBallistaTopMesh", gameObject);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.timeDelay = 1f;
        this.spawnLimit = 1000000000;
    }
    protected override void InitializePrefab()
    {
        if (ballistaLookAtTager.IsLookAtTaget == false) return;
        base.InitializePrefab();
    }

    protected override void ConfigurePrefab()
    {
        prefab = this.RandomPrefab();
        pos = prefab.transform.position;
        rotation = ballistaTopMesh.transform.rotation;
    } 

}
