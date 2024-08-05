using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class BallistaSpawner : Spawner
{
    private static BallistaSpawner instance;
    public static BallistaSpawner Instance { get => instance; }

    public string ballistaOne = "BallistaOne";
    public string ballistaTwo = "BallistaTwo";


    protected override void Awake()
    {
        base.Awake();
        if (BallistaSpawner.instance != null) Debug.LogError("Only 1 BallistaSpawner allow to exist");
        BallistaSpawner.instance = this;
    }

}
    



