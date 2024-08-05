using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnBallistaByMouse : GameMonoBehaviour
{
    [SerializeField] protected int ballistaOneCost = 5;
    [SerializeField] protected int ballistaTwoCost = 10;
    [SerializeField] protected string nameBallista;
    [SerializeField] protected string nameNull = "string";

    public LayerMask groundLayerMask;
    public LayerMask ballistaLayerMask;

    protected override void Start()
    {
        base.Start();
        this.nameBallista = this.nameNull;
    }

    void Update()
    {
        this.HandleMouseClick();
    }

    public virtual void HandleMouseClick()
    {
        if (nameBallista == nameNull) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit enemyHit, Mathf.Infinity, ballistaLayerMask))
            {
                return;
            }

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayerMask))
            {
                Vector3 spawnPosition = hit.point;
                spawnPosition.y = 0;
                Quaternion spawnQuaternion = Quaternion.identity;

                Transform ballista = BallistaSpawner.Instance.Spawn(nameBallista, spawnPosition, spawnQuaternion);
                ballista.gameObject.SetActive(true);
                this.Deduction();

                nameBallista = nameNull;             
            }
        }
    }

    protected virtual void Deduction()
    {
        if(nameBallista == BallistaSpawner.Instance.ballistaOne)
        {
            BankManager.Instance.Withdraw(ballistaOneCost);
        }

        if (nameBallista == BallistaSpawner.Instance.ballistaTwo)
        {
            BankManager.Instance.Withdraw(ballistaTwoCost);
        }
    }    

    public virtual void SetNameBallista(string nameBallista)
    {
        this.nameBallista = nameBallista;
    }

}
