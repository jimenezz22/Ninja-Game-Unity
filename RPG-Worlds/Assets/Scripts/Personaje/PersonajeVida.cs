using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterLife : VidaBase
{   
    public static Action EventCharacterDead; //Event that will be triggered when the character is defeated
    public bool CanBeCareful => Health < maxHealth; //if the health is less than the max health, the character can be healed

    public bool Derrotado { get; private set; } //propiedad para saaber si el personaje fue derrotado

    private BoxCollider2D _boxCollider2D; //reference to the BoxCollider2D component

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>(); //get the BoxCollider2D component
    }

    protected override void Start()
    {
        base.Start(); //call the start method of the parent class
        UpdateHealthBar(Health, maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) //if the key T is pressed
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.Y)) //if the key R is pressed
        {
            RestoreHealth(10);
        }
    }

    public void RestoreHealth(float quantity)
    {   
        if (Derrotado) return; //Validation: if the character is defeated, return

        //Restore the health of the character
        if (CanBeCareful)
        {
            Health += quantity;
            
            if (Health > maxHealth)
            {
                Health = maxHealth;
            }

            UpdateHealthBar(Health, maxHealth);
        }
    }

    protected override void CharacterDestroy()
    {   
        Derrotado = true; //set the defeated property to true

        //this line of code is disabling the _boxCollider2D collider, which means it will stop interacting with other physics 
        //objects and stop triggering events. This might be done, for example,  if the character has been destroyed and 
        //should no longer interact with the game world.
        _boxCollider2D.enabled = false; //disable the BoxCollider2D component

        EventCharacterDead?.Invoke(); //trigger the event
    }

    public void RevivirPersonaje()
    {
        _boxCollider2D.enabled = true; //enable the BoxCollider2D component
        Derrotado = false; //set the defeated property to false
        Health = maxHealth; //set the health to the maximum health 
        UpdateHealthBar(Health, maxHealth); //update the health bar
    }

    protected override void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        //Update the health bar with a reference to the UIManager
        UIManager.Instance.ActualizarVidaPersonaje(currentHealth, maxHealth);
    }
}