using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float maxHealth;
    protected float curHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        curHealth = maxHealth;
    }

    public virtual void TakeDamage(float dmg) 
    {
        Debug.Log($"Entity {this.name} has taken {dmg} damage");
        curHealth -= dmg;
        if (curHealth <= 0) die();
    }

    protected virtual void die()
    {
        Debug.Log($"{this.name} has died");
    }
}
