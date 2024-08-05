using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldText : BaseText
{
    private void FixedUpdate()
    {
        this.GoldShowing();
    }

    protected virtual void GoldShowing()
    {
        int currentGold = BankManager.Instance.CurrentBalance;
        this.text.text = "Gold : " + currentGold.ToString();
    }
}
