using System;
using UnityEngine;

public class AutoHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 200;
    public int health;
    public event Action OnDie;


    public bool IsDie = false;

    private void Awake()
    {
        health = maxHealth;
        IsDie = false;
    }

    private void Start()
    {
;
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

        //GameManager.Instance.hpGaugeSlider.value = health / maxHealth;
        GameManager.Instance.UpdateHealthUI();
        Debug.Log(health);
    }
}