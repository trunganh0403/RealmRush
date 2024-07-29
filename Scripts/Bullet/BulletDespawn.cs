using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDespawn : GameMonoBehaviour
{
    [SerializeField] private BulletSpawner bulletSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletSpawner();
    }

    protected virtual void LoadBulletSpawner()
    {
        if (this.bulletSpawner != null) return;
        this.bulletSpawner = transform.parent.parent.parent.parent.Find("BulletSpawner").GetComponent<BulletSpawner>();
        Debug.LogWarning(transform.name + ": LoadBulletSpawner", gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(Tag.Car)) return;

        bulletSpawner.Despawn(transform.parent);
    }
}
