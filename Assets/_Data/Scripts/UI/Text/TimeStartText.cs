using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeStartText : BaseText
{
    [SerializeField] protected float timeDelay = 30;
    [SerializeField] protected float currenTime;
    [SerializeField] private int timeStart;
    [SerializeField] private ButtonStart buttonStart;

    public int TimeStart => timeStart; 

    protected override void Start()
    {
        base.Start();
        currenTime = timeDelay;
    }
    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButtonStart();
    }

    protected virtual void LoadButtonStart()
    {
        if (this.buttonStart != null) return;
        this.buttonStart = FindAnyObjectByType<ButtonStart>();
        Debug.LogWarning(transform.name + ": LoadButtonStart", gameObject);
    }

    protected virtual void Shooting()
    {
        currenTime -= Time.fixedDeltaTime;
        timeStart = Convert.ToInt32(currenTime);
        text.text = timeStart.ToString();     

        if (currenTime <=0)
        {
            buttonStart.StartGameSequence();
        }
    }
}
