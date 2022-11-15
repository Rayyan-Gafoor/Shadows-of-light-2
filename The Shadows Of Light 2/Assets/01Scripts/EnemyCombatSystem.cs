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
    public GameObject lazer;

    [Header("Combat Stats")]
    public bool engage;
    public bool attacked;
    public bool lazer_on;
    public bool resting;
    public float time_between_normals;

    [Header("References")]
    public GameObject normal_spawn_point;
    public GameObject lazer_spawn_point;
    public GameObject smoke_effects;
    public GameObject Player;
    Projectile projectile_stats;
    EnemyAI enemy_ai;
    private void Start()
    {
        Player = GameObject.Find("Player");
        projectile_stats = normal_projectiles.GetComponent<Projectile>();
        enemy_ai = GetComponent<EnemyAI>();
        engage = true;
    }
    private void Update()
    {
        state_controller();
        if (engage)
        {
            engage = false;
            StartCoroutine(combat_controller());
        } 
    }
    #region Combat Phases
    void phase_one()
    {
        projectile_stats.enemy_damage = enemy_normal_damage;
        //normal ranged attack
        enemy_ai.can_move = true;
        enemy_ai.can_look = true;
        if (!attacked)
        {
            Rigidbody rb = Instantiate(normal_projectiles, normal_spawn_point.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 1f, ForceMode.Impulse);
            rb.AddForce(transform.up * 1f, ForceMode.Impulse);
            attacked = true;
            Invoke(nameof(reset_attack), time_between_normals);
        }
    }
    void phase_two()
    {
        //enable the lazer -  stop and rotate enemy 
        enable_lazer();
        enemy_ai.can_move = false;
        enemy_ai.can_look = true;
    }
    void phase_rest()
    {
        //resting = true;
        lazer_on = false;
        enemy_ai.can_attack = false;
        enemy_ai.can_move = false;
        enemy_ai.can_look = false;
        smoke_effects.SetActive(true);
    }
    #endregion
   

    IEnumerator combat_controller()
    {
        state = enemy_states.normal_ranged;
        yield return new WaitForSeconds(20f);
        state = enemy_states.degree_laser;
        yield return new WaitForSeconds(7f);
        state = enemy_states.rest;
        yield return new WaitForSeconds(10f);
        engage = true;

    }
    void state_controller()
    {
        if (state == enemy_states.normal_ranged)
        {
            phase_one();
            enemy_ai.can_attack = true;
            lazer_on = false;
            resting = false;
            disble_lazer();
            smoke_effects.SetActive(false);
        }
        if (state == enemy_states.degree_laser)
        {
            phase_two();
            enemy_ai.can_attack = false;
            lazer_on = true;
            resting = false;
            enable_lazer();
            smoke_effects.SetActive(false);
        }
        if (state == enemy_states.rest)
        {
            phase_rest();
            disble_lazer();
            enemy_ai.can_attack = false;
            lazer_on = false;
            resting = true;
        }
    }
    #region misc
    void enable_lazer()
    {
        lazer.SetActive(true);
    }
    void disble_lazer()
    {
        lazer.SetActive(false);
    }

    void reset_attack()
    {
        attacked = false;
    }
    #endregion
  
}
