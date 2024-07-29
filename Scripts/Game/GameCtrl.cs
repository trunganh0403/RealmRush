using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : GameMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance { get => instance; }

    [SerializeField] private RoadSpawner roadSpawner;
    public RoadSpawner RoadSpawner { get => roadSpawner; } 

    //[SerializeField] private BallistaCtrl ballistaCtrl;
    //public BallistaCtrl BallistaCtrl { get => ballistaCtrl; }

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
        //this.LoadBallistaCtrl();
    }

    protected virtual void LoadRoadSpawner()
    {
        if (this.roadSpawner != null) return;
        this.roadSpawner = FindAnyObjectByType<RoadSpawner>();
        Debug.LogWarning(transform.name + ": LoadRoadSpawner", gameObject);
    }
    
    //protected virtual void LoadBallistaCtrl()
    //{
    //    if (this.ballistaCtrl != null) return;
    //    this.ballistaCtrl = FindAnyObjectByType<BallistaCtrl>();
    //    Debug.LogWarning(transform.name + ": LoadBallistaCtrl", gameObject);
    //}
}
