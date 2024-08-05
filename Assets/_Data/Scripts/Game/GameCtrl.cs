using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : GameMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance { get => instance; }

    [SerializeField] private RoadSpawner roadSpawner;
    public RoadSpawner RoadSpawner { get => roadSpawner; }    
    
    [SerializeField] private CarRandom carRandom;
    public CarRandom CarRandom { get => carRandom; }  
    
    [SerializeField] private SpawnBallistaByMouse spawnBallistaByMouse;
    public SpawnBallistaByMouse SpawnBallistaByMouse { get => spawnBallistaByMouse; } 


    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) Debug.LogError("Only 1 GameCtrl allow to exist");
        GameCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRoadSpawner();
        this.LoadCarRandom();
        this.LoadSpawnBallistaByMouse();
    }

    protected virtual void LoadRoadSpawner()
    {
        if (this.roadSpawner != null) return;
        this.roadSpawner = FindAnyObjectByType<RoadSpawner>();
        Debug.LogWarning(transform.name + ": LoadRoadSpawner", gameObject);
    }

    protected virtual void LoadCarRandom()
    {
        if (this.carRandom != null) return;
        this.carRandom = FindAnyObjectByType<CarRandom>();
        Debug.LogWarning(transform.name + ": LoadCarRandom", gameObject);
    }

     protected virtual void LoadSpawnBallistaByMouse()
    {
        if (this.spawnBallistaByMouse != null) return;
        this.spawnBallistaByMouse = FindAnyObjectByType<SpawnBallistaByMouse>();
        Debug.LogWarning(transform.name + ": LoadSpawnBallistaByMouse", gameObject);
    }

}
