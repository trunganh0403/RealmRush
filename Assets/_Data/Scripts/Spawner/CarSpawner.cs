using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class CarSpawner : Spawner
{
    private static CarSpawner instance;
    public static CarSpawner Instance { get => instance; }

    public string carOne = "CarOne";
    public string carTwo = "CarTwo";

    protected override void Awake()
    {
        base.Awake();
        if (CarSpawner.instance != null) Debug.LogError("Only 1 CarSpawner allow to exist");
        CarSpawner.instance = this;
    }       
}
