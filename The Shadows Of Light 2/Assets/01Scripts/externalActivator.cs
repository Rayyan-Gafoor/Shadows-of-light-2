using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class externalActivator : MonoBehaviour
{
    [Header("Internal Activation")]
    public bool internal_activator;
    public float flag_requirement;
    public float current_flag;

    [Header("External Object")]
    public bool external_activator;
    public GameObject to_activate;
    ComeAlive come_alive;

    [Header("Interactor Comps")]
    public bool can_interact;
    public GameObject UI;
    public GameObject object_activated;
    public GameObject object_deactivated;
    public GameObject door;

    activateDoor door_sc;
    private void Start()
    {
        door_sc = door.GetComponent<activateDoor>();
        can_interact = false;
        if (to_activate != null)
        {
            come_alive = to_activate.GetComponent<ComeAlive>();
        }
    }
    private void Update()
    {
        //self_activate();
        Interact();
        check_activation();
    }
    void check_activation()
    {
        if(flag_requirement== current_flag)
        {
            internal_activator = true;
        }
    }
    /*void self_activate()
    {
        if (internal_activator == true)
        {
            can_interact = true;
        }
    }*/
    void Interact()
    {
        if (can_interact)
        {
            if (Input.GetKey(KeyCode.E))
            {
                door_sc.flag += 1;
                UI.SetActive(false);
                if (external_activator)
                {
                    come_alive.is_alive = true;
                }
                if (object_activated != null)
                {
                    object_activated.SetActive(true);

                }
                if (object_deactivated != null)
                {
                    object_deactivated.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" & internal_activator==true)
        {
            can_interact = true;
            UI.SetActive(true);
            Debug.Log("Player reached");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" & internal_activator == true)
        {
            can_interact = false;
            UI.SetActive(false);
            Debug.Log("Player Exit");
        }
    }
}
