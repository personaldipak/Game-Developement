
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour {

    public float MaxHealth;
    public float CurrentHealth { get; set; }

    public Slider Healthslider;

    public Stat damage;
    public Stat armour;

    void Awake()
    {
        CurrentHealth = MaxHealth;
        Healthslider.value = CalaculateHealth();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage( int damage)
    {
       damage -= armour.Getvalue();
       damage = Mathf.Clamp(damage, 0, int.MaxValue);
     
        CurrentHealth -= damage;
        Healthslider.value = CalaculateHealth();
        Debug.Log(transform.name + "takes" + damage + "damage");

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void HealDamage(int HealAmount)
    {
        CurrentHealth += HealAmount;
        Healthslider.value = CalaculateHealth();
        Debug.Log(transform.name + "heal " + HealAmount + "points");
    }

    float CalaculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + "died");
    }
}﻿

