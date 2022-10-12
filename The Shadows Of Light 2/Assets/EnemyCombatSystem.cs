using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatSystem : MonoBehaviour
{
    public enemy_states state;
    public enum enemy_states
    {
        normal_ranged,
        degree_laser,
        missle_launch,
        rest
    }
    [Header("Enemy Data")]
    public float enemy_normal_damage;

    [Header("Enemy Weapons")]
    public GameObject normal_projectiles;

    [Header("Combat Stats")]
    public bool attacked;
    public float time_between_normals;

    [Header("References")]
    public GameObject normal_spawn_point;
    public GameObject Player;
    Projectile projectile_stats;
    EnemyAI enemy_ai;
    private void Start()
    {
        Player = GameObject.Find("Player");
        projectile_stats = normal_projectiles.GetComponent<Projectile>();
        enemy_ai = GetComponent<EnemyAI>();
    }
    private void Update()
    {
        if (enemy_ai.can_attack)
        {
            phase_one();
        }
    }
    void phase_one()
    {
        projectile_stats.enemy_damage = enemy_normal_damage;
        //normal ranged attack
        if (!attacked)
        {
            Rigidbody rb = Instantiate(normal_projectiles, normal_spawn_point.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 1f, ForceMode.Impulse);
            rb.AddForce(transform.up * 1f, ForceMode.Impulse);
            attacked = true;
            Invoke(nameof(reset_attack), time_between_normals);
        }
    }

    void reset_attack()
    {   
        attacked = false;
    }
}
