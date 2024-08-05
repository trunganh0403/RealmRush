using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaShooting : DelayedSpawner
{
    [SerializeField] protected BallistaCtrl ballistaCtrl;
    [SerializeField] protected string bulletName;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBallistaCtrl();
    }

    protected virtual void LoadBallistaCtrl()
    {
        if (this.ballistaCtrl != null) return;
        this.ballistaCtrl = transform.parent.GetComponent<BallistaCtrl>();
        Debug.LogWarning(transform.name + ": LoadBallistaCtrl", gameObject);
    }

    private void Update()
    {
        this.SetIsRandom();
    }

    protected override void SpawnObj()
    {
        base.SpawnObj();
        this.SetBullet();

        Vector3 spawmPos = ballistaCtrl.BallistaTopMesh.transform.position;
        Quaternion quaternion = ballistaCtrl.BallistaTopMesh.transform.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawmPos, quaternion);

        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
    }

    protected virtual void SetBullet()
    {
        if(transform.parent.name == BallistaSpawner.Instance.ballistaOne)
        {
            bulletName = BulletSpawner.Instance.bulletOne;
        }

        if (transform.parent.name == BallistaSpawner.Instance.ballistaTwo)
        {
            bulletName = BulletSpawner.Instance.bulletTwo;
        }
    }    

    protected virtual void SetIsRandom()
    {
        this.IsDelay = ballistaCtrl.BallistaLookAtTager.IsLookAtTaget;
    }

}
