using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem3 : MonoBehaviour
{
    private Animator anim;
    public GameObject player_model;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;

    [Header("Weapon and UI stats")]
    public GameObject weapon1;
    public GameObject player_stats;
    public bool in_combat;
    public bool weapon_isactive;
    public bool UI_isactive;
    public float weapon_active_time, ui_active_time;
    public float weapon_active_time_current, ui_active_time_current;

    private void Start()
    {
        anim = player_model.GetComponent<Animator>();
        weapon1.SetActive(false);
        player_stats.SetActive(false);
        UI_isactive = false;
        weapon_isactive = false;


    }
    void Update()
    {


        exit_attack();
        weapon_controller();
        //cooldown time
        if (Time.time > nextFireTime)
        {
            // Check for mouse input
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();

            }
        }
    }

    void OnClick()
    {
        //so it looks at how many clicks have been made and if one animation has finished playing starts another one.
        lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            anim.SetBool("hit1", true);
            //anim.SetTrigger("Attack1");

        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f && anim.GetCurrentAnimatorStateInfo(0).IsName("sideSlash"))
        {
            anim.SetBool("hit1", false);
            anim.SetBool("hit2", true);
            Debug.Log("called Attack2");
            //anim.SetTrigger("Attack2");

        }
        if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f && anim.GetCurrentAnimatorStateInfo(0).IsName("downSlash"))
        {
            anim.SetBool("hit2", false);
            anim.SetBool("hit3", true);
           // Debug.Log("called Attack3");
           // anim.SetTrigger("Attack3");

        }
    }

    void exit_attack()
    {
        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).nameHash);
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("sideSlash"))
        {
            anim.SetBool("hit1", false);
            Debug.Log("exit attack 1");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("downSlash"))
        {
            anim.SetBool("hit2", false);
            Debug.Log("exit attack 2");

        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("ComboAttack"))
        {
            anim.SetBool("hit3", false);
            Debug.Log("exit attack 3");

            noOfClicks = 0;
        }


        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
    }
    void weapon_controller()
    {
        if (weapon_active_time_current > 0)
        {
            weapon1.SetActive(true);
            weapon_active_time_current -= Time.deltaTime;
        }
        if (weapon_active_time_current <= 0 & weapon_isactive == true)
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
        if (Input.GetMouseButtonDown(0))
        {
            weapon_active_time_current = weapon_active_time;
            ui_active_time_current = ui_active_time;
            weapon_isactive = true;
            //animation_controller();
            //combo_count++;
        }
    }
}
