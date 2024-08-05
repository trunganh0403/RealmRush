using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : BaseButton
{
    [SerializeField] TimeStartText timeStartText;
    protected override void OnClick()
    {
        this.StartGameSequence();
    }

    public virtual void StartGameSequence()
    {
        GameCtrl.Instance.CarRandom.IsDelay = true;
        BankManager.Instance.Deposit(timeStartText.TimeStart);
        this.ToggleButtonVisibility(false);
    }    
}
