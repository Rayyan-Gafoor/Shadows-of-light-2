using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float look_radius = 30f;
    public float attack_radius = 20f;
    public GameObject player;
    public bool can_move;
    public bool can_attack;
    Transform target;
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attack_radius;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= look_radius)
        {
            can_attack = true;
            if (can_move)
            {
                agent.SetDestination(target.position);
            }
            face_target();

            if (distance < agent.stoppingDistance)
            {
                //attack
            }
        }
        else
        {
            can_attack = false;
        }
    }
    void face_target()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion look_rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, look_rotation, Time.deltaTime * 5f); ;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, look_radius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attack_radius);
    }
}
