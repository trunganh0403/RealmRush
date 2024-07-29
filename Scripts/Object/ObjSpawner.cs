using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjSpawner : Spawner
{

    [SerializeField] protected Transform prefab;
    [SerializeField] protected Vector3 pos;
    [SerializeField] protected Quaternion rotation;

    [SerializeField] protected float currentTime;
    [SerializeField] protected float timeDelay = 2f;
    [SerializeField] protected int spawnLimit = 10;

    //public Transform Prefab => prefab;

    private void FixedUpdate()
    {
        this.InitializePrefab();
    }

    protected virtual void InitializePrefab()
    {
        this.ConfigurePrefab();
        this.ObjSpawning(prefab, pos, rotation);
    }

    protected abstract void ConfigurePrefab();


    protected virtual void ObjSpawning(Transform prefab, Vector3 pos, Quaternion rotation)
    {
        if (this.RandomReachLimit()) return;

        UpdateRandomTime();
        if (this.currentTime < this.timeDelay) return;
        ResetRandomTime();

        Transform obj = this.Spawn(prefab, pos, rotation);
        ActivateObject(obj);
    }

    protected void UpdateRandomTime()
    {
        this.currentTime += Time.fixedDeltaTime;
    }

    protected void ResetRandomTime()
    {
        this.currentTime = 0;
    }

    protected void ActivateObject(Transform obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.SpawnedCount;
        return currentJunk>= spawnLimit;
    }
}
