using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTriggers : MonoBehaviour
{
    public GameObject Player;
    public GameObject tut_ui;
    public GameObject instruction_text;
    public GameObject exit_text;
    public GameObject tut_cam;
    public string text_input;
    public bool done;
    public bool can_exit;

    ThirdPersonCharacterController player_controller;

    private void Start()
    {
        done = false;
        exit_text.SetActive(false);
        can_exit = false;
        player_controller = Player.GetComponent<ThirdPersonCharacterController>();
    }
     void Update()
    {
        StartCoroutine(exit_tut());
        if(can_exit && Input.GetMouseButton(0))
        {
            done = true;
       
            tut_cam.SetActive(false);
            player_controller.can_move = true;
            tut_ui.SetActive(false);
            exit_text.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!done)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                tut_cam.SetActive(true);
                tut_ui.SetActive(true);
                player_controller.can_move = false;
                instruction_text.GetComponent<TMPro.TextMeshProUGUI>().text = text_input;
            }
            else
            {
                return;
            }
        }
       
    }
    IEnumerator exit_tut()
    {
        yield return new WaitForSeconds(5f);
        exit_text.SetActive(true);
        can_exit = true;
        
    }
}
