using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaCtrl : GameMonoBehaviour
{
    [SerializeField] protected BallistaLookAtTager ballistaLookAtTager;
    public BallistaLookAtTager BallistaLookAtTager { get => ballistaLookAtTager; }

    [SerializeField] protected Transform ballistaTopMesh;
    public Transform BallistaTopMesh { get => ballistaTopMesh; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBallistaLookAtTager();
        this.LoadBallistaTopMesh();
    }

    protected virtual void LoadBallistaLookAtTager()
    {
        if (this.ballistaLookAtTager != null) return;
        this.ballistaLookAtTager = GetComponent<BallistaLookAtTager>();
        Debug.LogWarning(transform.name + ": BallistaLookAtTager", gameObject);
    }

    protected virtual void LoadBallistaTopMesh()
    {
        if (this.ballistaTopMesh != null) return;
        this.ballistaTopMesh = transform.Find("BallistaTopMesh"); 
        Debug.LogWarning(transform.name + ": LoadBallistaTopMesh", gameObject);
    }
}
