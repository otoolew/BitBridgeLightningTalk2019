using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TargetSensor : MonoBehaviour
{
    public FactionData FactionData;
    public float DetectionRadius;

    [SerializeField]protected Target currentTarget;
    public virtual Target CurrentTarget { get => currentTarget; set => currentTarget = value; }

    public List<Target> TargetList;
    public LayerMask TargetLayerMask;
    public LayerMask ObsticleLayerMask;

    protected virtual void Awake()
    {
        TargetList = new List<Target>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
            return;
        Target target = other.transform.root.GetComponent<Target>();

        if (target == null)
            target = other.GetComponentInParent<Target>();

        if (target == null)
            return;

        if (TargetList.Contains(target))
            return;

        if (IsTargetValid(target))
        {
            if (TargetVisable(target))
            {
                this.AddObserver(OnTargetRemoved, Notifications.DEATH_NOTIFICATION, target);
                TargetList.Add(target);
                CurrentTarget = GetNearestTarget();
                if (CurrentTarget != null)
                    this.PostNotification(Notifications.TARGET_ACQUIRED_NOTIFICATION, target);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger)
            return;
        Target targetUnit = other.transform.root.GetComponent<Target>();
        if (targetUnit == null)
            return;

        if (IsTargetValid(targetUnit))
        {
            OnTargetRemoved(targetUnit, null);
        }

    }
    void OnTargetRemoved(object sender, object e)
    {
        Target target = (Target)sender;
        this.RemoveObserver(OnTargetRemoved, Notifications.DEATH_NOTIFICATION, sender);
        for (int i = TargetList.Count - 1; i >= 0; i--)
        {
            if (TargetList[i] == target)
            {
                TargetList.RemoveAt(i);
                break;
            }
        }
        if(target = CurrentTarget)
        {
            CurrentTarget = null;
            this.PostNotification(Notifications.TARGET_LOST_NOTIFICATION, target);
        }

    }
    public bool IsTargetValid(Target targetArg)
    {
        if (targetArg == null || FactionData == null)
            return false;
        if (targetArg.FactionData == null)
            return false;
        return FactionData.CanHarm(targetArg.FactionData);
    }
    public bool TargetVisable(Target targetArg)
    {
        if (targetArg != null)
        {
            Vector3 directionToTargetable = (targetArg.TargetTransform.position - transform.position);
            float distanceToTargetable = Vector3.Distance(transform.position, targetArg.TargetTransform.position);

            if (!Physics.Raycast(transform.position, directionToTargetable, distanceToTargetable, ObsticleLayerMask))
            {
                Debug.DrawRay(transform.position, directionToTargetable, Color.green, 1f, false);
                return true;
            }
        }
        return false;
    }

    protected virtual Target GetNearestTarget()
    {
        if (TargetList.Count <= 0)
            return null;
        Target closestTarget = null;

        float closestDistance = DetectionRadius + 1;

        for (int i = TargetList.Count - 1; i >= 0; i--)
        {
            if (TargetList[i] == null)
                continue;

            Target target = TargetList[i].GetComponent<Target>();

            if (!target.IsDead)
            {
                float currentDistance = Vector3.Distance(transform.position, target.TargetTransform.position);
                if (currentDistance < closestDistance)
                {
                    closestDistance = currentDistance;
                    closestTarget = target;
                }
            }
            else
            {
                TargetList.RemoveAt(i);
            }
        }

        if (CurrentTarget != null)
        {
            this.PostNotification(Notifications.TARGET_ACQUIRED_NOTIFICATION);
        }

        return closestTarget;
    }
    protected virtual void ClearTargetList()
    {
        for (int i = TargetList.Count - 1; i >= 0; i--)
        {
            this.RemoveObserver(OnTargetRemoved, Notifications.DEATH_NOTIFICATION, TargetList[i]);
        }
        TargetList.Clear();
    }
#if UNITY_EDITOR

    private void OnValidate()
    {
        //collect the scene name
        if (GetComponent<SphereCollider>() != null)
            GetComponent<SphereCollider>().radius = DetectionRadius;
    }
#endif
}
