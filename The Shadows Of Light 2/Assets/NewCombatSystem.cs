using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCombatSystem : MonoBehaviour
{
    [Header("General Combat")]
    public LayerMask hit_object;
    public float attack_damage;

    [Header("Animation Control")]
    public GameObject player_model;
    public GameObject weapon1, weapon2;
    Animator animator;
    public float combo_count;
    public bool is_hold;
    public float original_combo_time;
    public float combo_time;

    private void Start()
    {
        animator = player_model.GetComponent<Animator>();
    }

    private void Update()
    {
        if (combo_time > 0)
        {
            combo_time -= Time.deltaTime;
            
        }
        if (combo_time <= 0)
        {
            combo_count = 0;
        }
        if (Input.GetMouseButtonDown(1))
        {
            animation_controller();
            combo_count++;
        }
    }

    void animation_controller()
    {
        if (combo_count == 0)
        {
            combo_time = original_combo_time;
            animator.SetTrigger("Attack1");
            return;
        }
        else if (combo_count == 1)
        {
            Debug.Log("Second Attack");
            animator.SetTrigger("Attack2");
            return;
        }
        else if (combo_count == 2)
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
}
