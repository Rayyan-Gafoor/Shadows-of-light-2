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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    void Interact()
    {
        if(Physics.CheckSphere(transform.position, range, player_mask, QueryTriggerInteraction.UseGlobal))
        {
            can_interact = true;
            Debug.Log("Player reached");
            
        }
        else
        {
            can_interact = false;

        }
        if (can_interact)
        {
            UI.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                UI.SetActive(false);
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
        if (!can_interact)
        {
            UI.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
