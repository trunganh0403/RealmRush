using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRandom : DelayedSpawner
{
    [SerializeField] protected int spawnLimit = 10;
    public  int SpawnLimit => spawnLimit;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.timeDelay = 2;
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = CarSpawner.Instance.SpawnedCount;
        return currentJunk>= spawnLimit;
    }
    protected override void SpawnObj()
    {
        base.SpawnObj();
        if (this.RandomReachLimit()) return;

        Vector3 spawmPos = CarSpawner.Instance.Prefabs[0].position; ;
        Quaternion quaternion = transform.parent.rotation;
        Transform newCar = CarSpawner.Instance.Spawn(CarSpawner.Instance.carOne, spawmPos, quaternion);
        if (newCar == null) return;
        newCar.gameObject.SetActive(true);
    }  
  
}
