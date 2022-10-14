using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewCombatSystem : MonoBehaviour
{
    [Header("General Combat")]
    public LayerMask hit_object;
    public float attack_damage;
    public float combat_range;
    public bool in_combat;
    public LayerMask enemy_mask;

    [Header("Combat UI")]
    public GameObject player_stats;

    [Header("Animation Control")]
    public GameObject player;
    public GameObject player_model;
    public GameObject weapon1, weapon2;
    Animator animator;
    public float combo_count;
    public bool is_attacking;
    public bool is_hold;
    public float original_combo_time;
    public float combo_time;

    [Header("Animation State")]
    AnimatorStateInfo anime_state;
    public float anime_time;
    public bool anime_done;

    [Header("Weapon and UI stats")]
    public bool weapon_isactive;
    public bool UI_isactive;
    public float weapon_active_time, ui_active_time;
    public float weapon_active_time_current, ui_active_time_current;

    ThirdPersonCharacterController player_controller;
    private void Start()
    {
        weapon1.SetActive(false);
        player_stats.SetActive(false);
        UI_isactive = false;
        weapon_isactive = false;
        animator = player_model.GetComponent<Animator>();
        player_controller = player.GetComponent<ThirdPersonCharacterController>();
        is_attacking = false;
    }

    private void Update()
    {
        if (is_attacking)
        {
            anime_state = animator.GetCurrentAnimatorStateInfo(0);
            anime_time = anime_state.normalizedTime;
            player_controller.can_move = false;
            if (anime_time > 0.25f)
            {
                is_attacking = false;
                player_controller.can_move = true;
            }
        }
        
        if (combo_time > 0)
        {
            combo_time -= Time.deltaTime;
            
        }
        if (combo_time <= 0)
        {
            combo_count = 0;
        }
        if (weapon_active_time_current > 0)
        {
            weapon1.SetActive(true);
            weapon_active_time_current -= Time.deltaTime;
        }
        if (weapon_active_time_current <= 0 & weapon_isactive==true)
        {
            weapon1.SetActive(false);
            weapon_isactive = false;
            // StartCoroutine(object_disable());
        }
        if (in_combat)
        {
            player_stats.SetActive(true);
            UI_isactive = true;
        }
        if (ui_active_time_current > 0 && !in_combat)
        {
            player_stats.SetActive(true);
            UI_isactive = true;
            ui_active_time_current -= Time.deltaTime;
        }
        if (ui_active_time_current <= 0 && !in_combat && UI_isactive)
        {
            player_stats.SetActive(false);
            UI_isactive = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            weapon_active_time_current = weapon_active_time;
            ui_active_time_current = ui_active_time;
            weapon_isactive = true;
            animation_controller();
            combo_count++;
        }
    }

   
    void animation_controller()
    {
        if (combo_count == 0 & !is_attacking)
        {
            combo_time = original_combo_time;
            animator.SetTrigger("Attack1");
            is_attacking = true;
            return;
        }
        else if (combo_count == 1 & !is_attacking)
        {
            Debug.Log("Second Attack");
            animator.SetTrigger("Attack2");
            return;
        }
        else if (combo_count == 2 & !is_attacking)
        {
            Debug.Log("Third Attack");
            animator.SetTrigger("Attack3");
            return;
        }
        else if (is_hold)
        {
            Debug.Log("Hold- Slam Attack");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, combat_range);
    }

}
