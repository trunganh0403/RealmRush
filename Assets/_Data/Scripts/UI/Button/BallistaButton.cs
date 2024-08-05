using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallistaButton : BaseButton
{
    [SerializeField] protected Image fillImage;
    [SerializeField] protected bool canClick = true;
    [SerializeField] protected float timeDelay = 3f;
    [SerializeField] protected float currentTime = 0f;

    protected override void Start()
    {
        base.Start();
        fillImage.fillAmount = 0f;
    }

    private void Update()
    {
        UpdateClickCooldown();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFillImage();
    }

    protected virtual void LoadFillImage()
    {
        if (this.fillImage != null) return;
        this.fillImage = transform.Find("FillImage").GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadFillImage", gameObject);
    }

    private void UpdateClickCooldown()
    {
        if (!canClick)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                canClick = true;
            }
            UpdateFillAmount();
        }
    }

    private void UpdateFillAmount()
    {
        if (fillImage != null)
        {
            fillImage.fillAmount = currentTime / timeDelay;
        }
    }
    protected override void OnClick()
    {
        this.HandleButtonClick();
    }

    protected virtual void HandleButtonClick()
    {
        if (!canClick) return;

        canClick = false;
        currentTime = timeDelay;
        fillImage.fillAmount = 1f;
    }
}
