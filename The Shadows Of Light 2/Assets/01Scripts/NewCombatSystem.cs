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

    [Header("New System")]
    public float cooldown_time = 2f;
    float next_firetime = 0f;
    public  int no_clicks = 0;
    float last_clicktime = 0;
    float maxComboDelay = 1;

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
        /*if (is_attacking)
        {
            anime_state = animator.GetCurrentAnimatorStateInfo(0);
            anime_time = anime_state.normalizedTime;
            player_controller.can_move = false;
            if (anime_time > 0.25f)
            {
                is_attacking = false;
                player_controller.can_move = true;
            }
        }*/
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime>0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("sideSlash"))
        {
            animator.SetBool("hit1", false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("downSlash"))
        {
            animator.SetBool("hit2", false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("ComboAttack"))
        {
            animator.SetBool("hit3", false);
            no_clicks = 0;
        }
        if (Time.time - last_clicktime > maxComboDelay)
        {
            no_clicks = 0;
        }
        if (Time.time > next_firetime)
        {
            if (Input.GetMouseButtonDown(1))
            {
                on_click();
            }
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
            //animation_controller();
            //combo_count++;
        }
    }

    void on_click()
    {
        last_clicktime = Time.time;
        no_clicks++;
        if (no_clicks == 1)
        {
            animator.SetBool("hit1", true);
        }
        no_clicks = Mathf.Clamp(no_clicks, 0, 3);

        if(no_clicks>= 2 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime>0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("sideSlash"))
        {
            animator.SetBool("hit1", false);
            animator.SetBool("hit2", true);
        }
        if (no_clicks >= 3 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("downSlash"))
        {
            animator.SetBool("hit2", false);
            animator.SetBool("hit3", true);
        }
    }
    /*void animation_controller()
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
    */
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, combat_range);
    }

}
