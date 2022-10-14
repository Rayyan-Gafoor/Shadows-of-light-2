using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTriggers : MonoBehaviour
{
    public GameObject Player;
    public GameObject scene_cam;
    public float scene_time;

    ThirdPersonCharacterController player_controller;

    void Start()
    {
        player_controller = Player.GetComponent<ThirdPersonCharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(start_scene());
        }
    }
    IEnumerator start_scene()
    {
        scene_cam.SetActive(true);
        player_controller.can_move = false;

        //play audio
        // do stuff
        yield return new WaitForSeconds(scene_time);
        scene_cam.SetActive(false);
        player_controller.can_move = true;
        this.gameObject.SetActive(false);

    }
}
