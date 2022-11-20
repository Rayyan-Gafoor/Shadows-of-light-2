using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    [Header("light Scene Settings")]
    public float start_color_temp;
    public float end_color_temp;
    public float current_temp;
    public Color start_color, end_color, current_color;
    public float duration;
    [Header("References")]
    public GameObject door;
    activateDoor activate;
    public GameObject light_gameobject;
    Light directional_light;
    public bool can_change;
    ThirdPersonCharacterController player_controller;
    public GameObject Player;

    [Header("Scene Control")]
    public GameObject tree_leaves;
    public GameObject tree_leaves2;
    public GameObject leaves_particles;

    [Header("Scene Camera")]
    public GameObject scene_cam;
    public float scene_time;
    /*public Color light_color;
    [Range(1500, 20000)]
    public float colourTemp;
    */

    // Start is called before the first frame update
    void Start()
    {
        player_controller = Player.GetComponent<ThirdPersonCharacterController>();
        can_change = false;
        activate = door.GetComponent<activateDoor>();
        directional_light = light_gameobject.GetComponent<Light>();
        current_color = start_color;
        current_temp = start_color_temp;
        directional_light.colorTemperature = current_temp;
        directional_light.color = current_color;

        tree_leaves.SetActive(false);
        tree_leaves2.SetActive(false);
        leaves_particles.SetActive(false);
        scene_cam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.T))
        {
            //Debug.Log("LC- This is a Test Fucntion");
            StartCoroutine(lerp_float(current_temp, start_color_temp, end_color_temp, duration));
            StartCoroutine(lerp_colour(current_color, start_color, end_color, duration));
            Debug.Log(current_color + "" + current_color);
        }*/
       

    }
    private void FixedUpdate()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player" && activate.light_can_change && can_change==false)
        {
            // Debug.Log("LC-Player Has Exited");
            can_change = true;
            StartCoroutine(start_scene());
            StartCoroutine(lerp_float(current_temp, start_color_temp, end_color_temp,duration));
            StartCoroutine(lerp_colour(current_color, start_color, end_color, duration));
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && activate.light_can_change && can_change == false)
        {
            // Debug.Log("LC-Player Has Exited");
            can_change = true;

            StartCoroutine(lerp_float(current_temp, start_color_temp, end_color_temp, duration));
            StartCoroutine(lerp_colour(current_color, start_color, end_color, duration));
        }
    }

    /* private void OnTriggerEnter(Collider other)
     {
         if (other.tag == "Player")
         {
             StartCoroutine(lerp_float(current_temp, end_color_temp, start_color_temp,  duration));
             StartCoroutine(lerp_colour(current_color, end_color, start_color,  duration));
         }
     }*/
    IEnumerator lerp_float(float lerped_value,float start, float end, float duration)
    {
        //Debug.Log("LC- Lerp Float function" + " called");
        float time_elapsed=0;
        while (time_elapsed < duration)
        {
            current_temp = Mathf.Lerp(start, end, time_elapsed/ duration);
           // Debug.Log("LC- current Temperature " + current_temp);
            directional_light.colorTemperature = current_temp;
            time_elapsed += Time.deltaTime ;
            yield return null;
            //  Debug.Log("LC- lerp FLoat called ");
            //  Debug.Log("LC- timer :"+time_elapsed);
        }
        // Debug.Log("LC- Lerp Float function" + " ended");
        lerped_value = end;
        

    }
    IEnumerator lerp_colour(Color lerped_colour, Color start, Color end, float duration)
    {
        float time_elapsed = 0;
        while (time_elapsed < duration)
        {
            current_color = Color.Lerp(start, end, time_elapsed / duration);
            directional_light.color = current_color;
            time_elapsed += Time.deltaTime;
            yield return null;

        }
        current_color = end;

    }

    IEnumerator start_scene()
    {
        scene_cam.SetActive(true);
        player_controller.can_move = false;
        yield return new WaitForSeconds(scene_time);
        tree_leaves.SetActive(true);
        tree_leaves2.SetActive(true);
        leaves_particles.SetActive(true);
        //play audio
        // do stuff
        yield return new WaitForSeconds(scene_time);
        scene_cam.SetActive(false);
        player_controller.can_move = true;
        this.gameObject.SetActive(false);

    }
}
