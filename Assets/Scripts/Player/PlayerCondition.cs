using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagalbe
{
    void TakePhysicalDamage(int damage);
}
public class PlayerCondition : MonoBehaviour, IDamagalbe
{
    public UICondion uicondition;

    Condition health { get { return uicondition.health; } }
    Condition hunger { get { return uicondition.hunger; } }
    Condition stamina { get { return uicondition.Stamina; } }

    public float noHungerHealthDecay;

    public event Action OnTakeDamage;

    void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if(hunger.CurValue == 0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if(health.CurValue == 0f)
        {
            Die();
        }
    }

    public void Heal(float amout)
    {
        health.Add(amout);
    }

    public void Eat(float amout)
    {
        hunger.Add(amout);
    }
    public void Die()
    {
        Debug.Log("ав╬З╢ы.");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        OnTakeDamage?.Invoke();
    }
}
