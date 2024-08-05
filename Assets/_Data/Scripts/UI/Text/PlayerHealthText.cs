using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthText : BaseText
{
    private void FixedUpdate()
    {
        this.GoldShowing();
    }

    protected virtual void GoldShowing()
    {
        int currentHealth = GameManager.Instance.CurentHp;
        this.text.text = "Health : " + currentHealth.ToString();
    }
}
