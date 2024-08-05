using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDespawn : Despawn
{
    [SerializeField] bool isDespawn;
    protected override bool CanDespawn()
    {
        return isDespawn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag.Car) || other.gameObject.CompareTag(Tag.Ground))
        {
            isDespawn = true;
        }
    }

    public override void DespawnObj()
    {
        BulletSpawner.Instance.Despawn(transform.parent.transform);
        isDespawn = false;

    }
}
