using System;
using UnityEngine;

public class AutoHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 200;
    public int health;
    public event Action OnDie;

    public bool IsDie = false;


    private void Start()
    {
        health = maxHealth;
        IsDie = false;
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        health = Mathf.Max(health - damage, 0);

        if (health == 0)
        {
            IsDie = true;
            OnDie?.Invoke();
        }

        Debug.Log(health);
    }
}