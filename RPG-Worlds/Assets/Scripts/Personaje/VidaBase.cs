using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float initialHealth;

    public float Health { get; protected set; } //property to get and set the health

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Health = initialHealth; //initialize the health with the initial health
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0) {
            return; //if the damage is less or equal to 0, return (validation)
        } 

        if (Health > 0f) {

            Health -= damage; //if the health is greater than 0, decrease the health by the damage
            UpdateHealthBar(Health, maxHealth); //update the health bar

            if (Health <= 0f) { //if the health is less or equal to 0
                UpdateHealthBar(Health, maxHealth);
                CharacterDestroy(); //destroy the character
            }
        }
    }

    protected virtual void UpdateHealthBar(float currentHealth, float maxHealth)
    {

    }

    protected virtual void CharacterDestroy()
    { //method to destroy the character
        
    }
}
