using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform orietation;
    public Transform player;
    public Transform player_model;
    public Rigidbody rb;
    public float rotation_speed;
    public GameObject endScene;

    // Start is called before the first frame update
    void Start()
    {
      
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        
        
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 view = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orietation.forward = view.normalized;

        float horizontal_input = Input.GetAxis("Horizontal");
        float vertical_input = Input.GetAxis("Vertical");
        Vector3 input_dir = orietation.forward * vertical_input + orietation.right * horizontal_input;

        if(input_dir!= Vector3.zero)
        {
            player_model.forward = Vector3.Slerp(player_model.forward, input_dir.normalized, Time.deltaTime * rotation_speed);
        }
    }
}
