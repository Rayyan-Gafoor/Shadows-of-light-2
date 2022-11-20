using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalexit : MonoBehaviour
{
    public GameObject exit_scene;
    public GameObject ui_interact;
    public bool can_interact;

    public bool cam_flag;
    // Start is called before the first frame update
    void Start()
    {
        exit_scene.SetActive(false);
        cam_flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && can_interact)
        {
            
            ui_interact.SetActive(false);
            exit_scene.SetActive(true);
            cam_flag = true;
        }
        if (cam_flag == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            can_interact = true;
            ui_interact.SetActive(true);
            //Debug.Log("Player reached");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            can_interact = false;
            ui_interact.SetActive(false);
            // Debug.Log("Player reached");
        }
    }
}
