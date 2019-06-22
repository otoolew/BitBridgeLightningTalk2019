using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class HealthDepletedEvent : UnityEvent<bool>{ }

public class HealthComponent : MonoBehaviour
{
    public float MaxHP;
    public float CurrentHP;
    public bool Dead;
    public HealthDepletedEvent OnHealthDepleted;

    public void ApplyDamage(float damageAmount)
    {
        if (Dead)
            return;
        CurrentHP -= damageAmount;
        if (CurrentHP <= 0)
        {
            Dead = true;
            OnHealthDepleted.Invoke(true);
        }
    }
}
