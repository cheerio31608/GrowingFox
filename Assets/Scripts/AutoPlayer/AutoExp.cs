using System;
using UnityEngine;

public class AutoExp : MonoBehaviour
{
    [SerializeField] public int maxExp = 10;
    public int curExp;
    public event Action OnLevelUp;

    private void Start()
    {
        curExp = 0;
    }

    public void TakeExp(int exp)
    {
        curExp += exp;

        if(curExp >= maxExp)
        {
            maxExp += 5;
            curExp = 0;
        }
        GameManager.Instance.UpdateExpUI();
    }
}