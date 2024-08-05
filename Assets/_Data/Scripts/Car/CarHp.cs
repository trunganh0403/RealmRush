using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHp : GameMonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp = 15;
    [SerializeField] protected int hpDeductOne = 1;
    [SerializeField] protected int hpDeductTwo = 2;
    [SerializeField] protected int enemyKillReward = 3;
    [SerializeField] protected bool isDead;
    [SerializeField] protected CarDestructionHandler carDestructionHandler;

    public int Hp => hp;
    public int MaxHp => maxHp;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    protected virtual void Reborn()
    {
        this.hp = this.maxHp;
        this.isDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(Tag.BulletOne))
        {
            this.Deduct(hpDeductOne);
        }

        if (other.gameObject.CompareTag(Tag.BulletTwo))
        {
            this.Deduct(hpDeductTwo);
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
        carDestructionHandler.IncrementDestroyedCarCount();
        this.CreateImpactFX();
        CarSpawner.Instance.Despawn(transform.parent);
        BankManager.Instance.Deposit(enemyKillReward);
    }

    protected virtual void CreateImpactFX()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.y = 0.4f;
        Transform fxImpact = FXSpawner.Instance.Spawn(FXSpawner.Instance.smoke, spawnPos, transform.rotation);
        fxImpact.gameObject.SetActive(true);
    }

}
