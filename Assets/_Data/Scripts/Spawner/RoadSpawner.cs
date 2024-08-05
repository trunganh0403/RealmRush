using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : GameMonoBehaviour
{
    [SerializeField] private List<Transform> prefabs;
    public List<Transform> Prefabs { get => prefabs;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }

        Debug.LogWarning(transform.name + ": LoadPrefabs", gameObject);
    }



}
