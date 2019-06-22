using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class SoldierController : MonoBehaviour
{
    public Animator Animator { get; set; } // Will not show in inspector
    public NavMeshAgent NavAgent { get; set; } // Will not show in inspector

    public bool enemyInRange;
    public float wonderRange;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        NavAgent = GetComponent<NavMeshAgent>();
        NavAgent.destination = transform.position + Vector3.forward * 5; // set destination 5 forward
    }

    // Update is called once per frame
    void Update()
    {
        // ALL OR NOTHING IN UPDATE
    }
    /// <summary>
    /// Gets a random point inside the circle area defined the node center and its radius
    /// </summary>
    /// <returns>A random point within the circle's area</returns>
    public Vector3 GetRandomPointInArea()
    {
        return new Vector3(transform.position.x + Random.Range(-wonderRange, wonderRange), 0f, transform.position.z + Random.Range(-wonderRange, wonderRange));
    }
}
