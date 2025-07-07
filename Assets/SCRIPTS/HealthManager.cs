using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar _healthBar;
    //public bool IsInvincible { get; set; }
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        _healthBar.setMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        _healthBar.setHealth(currentHealth);
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        // if (currentHealth == 0)
        // {
        //     OnDeath.Invoke();
        // }
    }
    
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    
    // Update is called once per frame
    void Update()
    {
       
    }
}
