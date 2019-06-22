using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthData : ScriptableObject
{
    public FactionData FactionData;
    public float MaxHP;
    public float CurrentHP;
    public bool IsDead;
    public void ApplyDamage(float damageAmountArg)
    {
        CurrentHP -= damageAmountArg;
        if (CurrentHP <= 0)
            IsDead = true;
    }
}
