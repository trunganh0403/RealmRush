using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameOver : MonoBehaviour
{

    //private void Update()
    //{
    //    GameManager.Instance.CheckIsDead();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(Tag.Car)) return;
        GameManager.Instance.Deduct(1);
    }
}
