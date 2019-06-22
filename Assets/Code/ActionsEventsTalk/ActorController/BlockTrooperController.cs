using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrooperController : Target
{
    #region Fields and Properties
    [Header("Trooper Controller Components")]
    public Animator Animator;
    public TargetSensor TargetSensor;
    public RaycastAttack RaycastAttack;
    public HealthComponent HealthComponent;

    [Header("Trooper Controller Fields")]
    public Target CurrentTarget;
    // public ITarget CurrentTarget; I would use this but for the demo I will use the field above
    #endregion

    #region MonoBehaviour
    // Start is called before the first frame update
    void Start()
    {
        InitHealthComponent();
        InitTargetSensor();
        InitRaycastAttack();
    }
    #endregion

    #region BlockTrooperController
    private void HandleTargetAcquired(object arg1, object arg2)
    {
        TargetSensor sender = (TargetSensor)arg1;
        Target target = (Target)arg2;
        Debug.Log(name + "'s " + sender.name + " Scanner has Acquired Target " + target.gameObject.name);
    }
    private void HandleTargetLost(object arg1, object arg2)
    {
        TargetSensor sender = (TargetSensor)arg1;
        Target target = (Target)arg2;
        Debug.Log(name + "'s " + sender.name + " Scanner has Lost Target " + target.gameObject.name);
    }
    private void HandleDeath(bool isDeadArg)
    {
        IsDead = isDeadArg;
        Animator.SetTrigger("Die");
        RemoveTarget(); // In base class Target
    }
    public void Kill()
    {
        Destroy(gameObject);
    }
    #endregion


    #region Initializing
    private void InitAnimator()
    {
        if (Animator == null)
            Animator.GetComponent<Animator>();
    }

    private void InitTargetSensor() // could change this to return a bool type aiding in future testing. Maybe next lightning talk!
    {
        if (TargetSensor == null)
            TargetSensor.GetComponentInChildren<TargetSensor>();
        TargetSensor.FactionData = FactionData;
        this.AddObserver(HandleTargetAcquired, Notifications.TARGET_ACQUIRED_NOTIFICATION, TargetSensor);
        this.AddObserver(HandleTargetLost, Notifications.TARGET_LOST_NOTIFICATION, TargetSensor);
    }

    private void InitRaycastAttack()
    {
        if (RaycastAttack == null)
            RaycastAttack.GetComponentInChildren<RaycastAttack>();
    }
    private void InitHealthComponent()
    {
        if (HealthComponent == null)
            HealthComponent.GetComponent<HealthComponent>();
        HealthComponent.OnHealthDepleted.AddListener(HandleDeath);
    }
    #endregion
}
