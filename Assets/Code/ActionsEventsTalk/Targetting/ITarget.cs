using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget : ISerializableInterface
{
    FactionData FactionData { get; set; }
    Transform TargetTransform { get; set; }
    bool IsDead { get; set; }
    T GetComponent<T>();
    void RemoveTarget();
}
/// <summary>
/// Concrete serializable version of interface above
/// </summary>
[Serializable]
public class ITargetComponent : SerializableInterface<ITarget>
{
}