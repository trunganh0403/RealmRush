using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestructionHandler : MonoBehaviour
{
    [SerializeField] private int destroyedCarCount = 0;
    [SerializeField] private CarRandom carRandom ;


    private void Update()
    {
        CheckDestroyedCarCount();
    }

    protected  virtual void CheckDestroyedCarCount()
    {
        if (destroyedCarCount >= carRandom.SpawnLimit)
        {
            GameManager.Instance.WinGame();
        }    
    }    

    public virtual void IncrementDestroyedCarCount()
    {
        destroyedCarCount++;
    }    
}
