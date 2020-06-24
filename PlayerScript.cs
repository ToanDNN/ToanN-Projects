using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    bool isHit = false;
    public float thrust;
    public float knockbackAmount;
    public bool knockFromRight;

    //public Interactable item;

    //Rigidbody2D rb;

    public HealthBarScript healthBar;

    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
       // rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
