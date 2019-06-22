using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAttack : MonoBehaviour
{
    public float Damage;
    public float Range;
    public float AttackCooldownTime;
    public Transform FirePoint;
    public LayerMask HitMask;
    private float lastAttackTime;

    private void Start()
    {
        lastAttackTime = Time.time;
    }

    //// NO UPDATE
    //private void Update()
    //{
        
    //}

    public void TriggerAttack()
    {
        if ((Time.time - lastAttackTime) < AttackCooldownTime)
            return;

        Ray ray = new Ray
        {
            origin = FirePoint.position,
            direction = FirePoint.forward,
        };

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Range, HitMask))
        {
            HealthComponent hitObject = raycastHit.collider.transform.root.GetComponent<HealthComponent>();
            //HealthComponent hitObject = raycastHit.collider.GetComponentInParent<HealthComponent>(); // can also do this
            if (hitObject != null)
            {
                Debug.DrawLine(ray.origin, raycastHit.point, Color.red, 0.5f);
                hitObject.ApplyDamage(Damage);
            }           
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.direction * Range, Color.yellow, 0.5f);
        }
        lastAttackTime = Time.time;
    }
}
