using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float range;
    public bool can_interact;
    public GameObject UI;
    public GameObject object_activated;
    public GameObject object_deactivated;
    public LayerMask player_mask;

    public bool is_external_activator;
    public GameObject external_object;
    externalActivator ea;

    public GameObject door;

    activateDoor door_sc;
    // Start is called before the first frame update
    void Start()
    {
        if (door != null)
        {
            door_sc = door.GetComponent<activateDoor>();
        }
        
        if (external_object != null)
        {
            ea = external_object.GetComponent<externalActivator>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    void Interact()
    {
      
        if (can_interact)
        {
           // UI.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                if (door != null)
                {
                    door_sc.flag += 1;
                }
                UI.SetActive(false);
                if (object_activated != null)
                {
                    object_activated.SetActive(true);
                    if (is_external_activator)
                    {
                        ea.current_flag = ea.current_flag + 1;
                    }
                }
                if (object_deactivated != null)
                {
                    object_deactivated.SetActive(false);
                }
            }
        }
        if (!can_interact)
        {
            //UI.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            can_interact = true;
             UI.SetActive(true);
            Debug.Log("Player reached");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            can_interact = false;
            UI.SetActive(false);
            Debug.Log("Player reached");
        }
    }
}
