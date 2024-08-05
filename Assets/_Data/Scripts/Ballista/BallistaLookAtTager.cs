using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaLookAtTager : GameMonoBehaviour
{
    [SerializeField] protected Transform currentTarget;
    [SerializeField] protected Transform ballistaTopMesh;
    [SerializeField] List<Transform> targets = new List<Transform>();
    [SerializeField] private bool isLookAtTaget = false;
    public bool IsLookAtTaget { get => isLookAtTaget; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBallistaTopMesh();
    }

    protected virtual void LoadBallistaTopMesh()
    {
        if (this.ballistaTopMesh != null) return;
        this.ballistaTopMesh = transform.Find("BallistaTopMesh").transform;
        Debug.LogWarning(transform.name + ": LoadBallistaTopMesh", gameObject);
    }

    private void FixedUpdate()
    {
        this.RemoveHiddenTargets();
        this.UpdateTarget();
        
    }

    protected virtual void UpdateTarget()
    {  
        if (targets.Count > 0)
        {
            currentTarget = targets[0]; 
            this.LookAtTaget(currentTarget);
        }
        else
        {
            currentTarget = null;
            isLookAtTaget = false;
        }
    }
    protected virtual void LookAtTaget(Transform target)
    {
        if (!isLookAtTaget || target == null) return;
        ballistaTopMesh.LookAt(target);
    }

    protected virtual void RemoveHiddenTargets()
    {
        if (targets.Count <= 0) return;
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            if (!targets[i].gameObject.activeInHierarchy)
            {
                targets.RemoveAt(i);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!other.gameObject.CompareTag(Tag.Car)) return;
        isLookAtTaget = true;

        if (targets.Contains(other.transform)) return;
        targets.Add(other.transform);

    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag(Tag.Car)) return;

        if (!targets.Contains(other.transform)) return;
        targets.Remove(other.transform);

        if (targets.Count == 0)
        {
            isLookAtTaget = false;
        }

    }

}
