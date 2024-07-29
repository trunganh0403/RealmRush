using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHp : GameMonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp = 5;
    [SerializeField] protected int hpDeduct = 1;
    [SerializeField] protected bool isDead;

    [SerializeField] protected CarSpawner carSpawner;

    public int Hp => hp;
    public int MaxHp => maxHp;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCarSpawner();
    }

    protected virtual void LoadCarSpawner()
    {
        if (this.carSpawner != null) return;
        this.carSpawner = FindAnyObjectByType<CarSpawner>();
        Debug.LogWarning(transform.name + ": LoadCarSpawner", gameObject);
    }

    protected virtual void Reborn()
    {
        this.hp = this.maxHp;
        this.isDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(Tag.Bullet))
        {
            this.Deduct(hpDeduct);
        }    
    }

    public virtual void Deduct(int add)
    {
        if (isDead) return;
        this.hp -= add;
        if (this.hp < 0) hp = 0;
        CheckIsDead();
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void OnDead()
    {
        carSpawner.Despawn(transform.parent);
        //this.ResetPos();
    }

    //public virtual void ResetPos()
    //{
    //    transform.parent.position = carSpawner.Prefab.position;
    //}    
}
