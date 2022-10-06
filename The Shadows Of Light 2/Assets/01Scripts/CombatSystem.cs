using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [Header("General Combat")]
    public LayerMask hit_object;
    public float attack_damage;
    [Header("Melee Combat")]
    public GameObject weapon_orb;
    public GameObject attack_point;
    public GameObject attack_endpoint;
    public float melee_reset;
    public float attack_speed;
    public bool attacking;
    public float frac = 0;
    [Header("Animation Control")]
    public GameObject player_model;
    Animator animator;
    public float combo_count;
    public float original_combo_time;
    public float combo_time;
    // Start is called before the first frame update
    void Start()
    {
        animator = player_model.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            weapon_orb.SetActive(true);
            attacking = true;
            animation_controller();
            Debug.Log("start attack");
        }
        if (attacking == true)
        {
            // StartCoroutine(melee_attack());
            combo_timer();
            melee_attack();
            Debug.Log("attacking");
        }
        if (combo_time<=0)
        {

            Debug.Log("stop attack");
            stop_attack();
        }

    }

   
    void melee_attack()
    {

        frac += Time.deltaTime * attack_speed;
        weapon_orb.transform.position = Vector3.Lerp(attack_point.transform.position, attack_endpoint.transform.position, frac);

    }
    void stop_attack()
    {
        attacking = false;
        weapon_orb.SetActive(false);
        frac = 0;
        weapon_orb.transform.position = attack_point.transform.position;
    }
    void animation_controller()
    {
        
        if (combo_count == 0)
        {
            animator.SetTrigger("Attack1");
        }
    }
    void combo_timer()
    {
        combo_time = original_combo_time;
        combo_time -= Time.deltaTime;
        if (combo_time <= 0)
        {
            Debug.Log("combo cancled");
        }

    }
}
