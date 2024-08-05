using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : GameMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    [SerializeField] protected int maxHp = 10;
    [SerializeField] protected int curentHp;
    [SerializeField] protected bool isDead;
    public int MaxHp => maxHp;
    public int CurentHp => curentHp;

    protected override void Awake()
    {
        base.Awake();
        if (GameManager.instance != null) Debug.LogError("Only 1 GameManager allow to exist");
        GameManager.instance = this;

        curentHp = maxHp;
        isDead = false;

        Time.timeScale = 1.0f;
    }
   
    public virtual void WinGame()
    {
        EndGame(true);
    }

    public virtual void LoseGame()
    {
        EndGame(false);
    }

    public void EndGame(bool hasWon)
    {
        Time.timeScale = 0.01f;

        if (hasWon)
        {
            WinGamePn.Instance.Open();        

        }
        else
        {
            LoseGamePn.Instance.Open();          
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public virtual void Deduct(int deduct)
    {
        if (this.isDead) return;

        this.curentHp -= deduct;
        if (this.curentHp < 0) this.curentHp = 0;
        this.CheckIsDead();
    }

    public virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.LoseGame();
    }

    public virtual bool IsDead()
    {
        return this.curentHp <= 0;
    }

}
