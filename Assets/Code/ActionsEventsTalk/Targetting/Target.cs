using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public FactionData FactionData;
    public Transform TargetTransform;
    public bool IsDead;
    protected virtual void RemoveTarget()
    {
        this.PostNotification(Notifications.DEATH_NOTIFICATION);
    }
}
