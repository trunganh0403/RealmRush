using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallistaTwoBt : BallistaButton
{
    [SerializeField] protected float timeDelayOvr = 5f;
    protected override void ResetValue()
    {
        base.ResetValue();
        timeDelay = timeDelayOvr;
    }
    protected override void OnClick()
    {
        if (BankManager.Instance.CurrentBalance < 10) return;
        if (!canClick) return;
        GameCtrl.Instance.SpawnBallistaByMouse.SetNameBallista(this.gameObject.name);

        base.OnClick();
    }

}
