using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFeedBack : MonoBehaviour
{
    public GameObject run_particle, run_cement;
    public GameObject walk_particle, walk_cement;
    public GameObject jump_particle;
    public GameObject tread_particle;
    public ParticleSystem swim_particle;
    public GameObject swim_obj;
    public float particle_time;
    public float ground_flag;
    
    public float player_height;
    public float height_offset;
    public LayerMask gorund_type;
    public Vector3 collision = Vector3.zero;

    ThirdPersonCharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        
        controller = gameObject.GetComponent<ThirdPersonCharacterController>();
        swim_particle = swim_obj.GetComponent<ParticleSystem>();
        StartCoroutine(stop_particles());

    }
    private void FixedUpdate()
    {
        get_data();
    }
    // Update is called once per frame
    void Update()
    {
        if (controller.walking_particle)
        {
            if (ground_flag == 0)
            {
                walk_particle.SetActive(true);
                walk_cement.SetActive(false);
                run_particle.SetActive(false);
                run_cement.SetActive(false);
                swim_particle.enableEmission = false;
                StartCoroutine(stop_particles());
                tread_particle.SetActive(false);
                jump_particle.SetActive(false);
            }
            else if (ground_flag == 1)
            {
                walk_particle.SetActive(false);
                walk_cement.SetActive(true);
                run_particle.SetActive(false);
                run_cement.SetActive(false);
                swim_particle.enableEmission = false;
                StartCoroutine(stop_particles());
                tread_particle.SetActive(false);
                jump_particle.SetActive(false);
            }

        }
        if (controller.running_particle)
        {

            if (ground_flag == 0)
            {
                walk_particle.SetActive(true);
                walk_cement.SetActive(false);
                run_particle.SetActive(true);
                run_cement.SetActive(false);
                swim_particle.enableEmission = false;
                StartCoroutine(stop_particles());
                tread_particle.SetActive(false);
                jump_particle.SetActive(false);
            }
            else if (ground_flag == 1)
            {
                walk_particle.SetActive(false);
                walk_cement.SetActive(false);
                run_particle.SetActive(false);
                run_cement.SetActive(true);
                swim_particle.enableEmission = false;
                StartCoroutine(stop_particles());
                tread_particle.SetActive(false);
                jump_particle.SetActive(false);
            }
        }
        if (controller.swimming_particle)
        {
            walk_particle.SetActive(false);
            run_particle.SetActive(false);
            if (swim_particle.isPlaying == false)
            {
                swim_particle.Play();
                swim_particle.enableEmission = true;
            }
            tread_particle.SetActive(false);
            jump_particle.SetActive(false);
        }
        if (controller.thread_particle)
        {
            walk_particle.SetActive(false);
            run_particle.SetActive(false);
            swim_particle.enableEmission = false;
            StartCoroutine(stop_particles());
            tread_particle.SetActive(true);
            jump_particle.SetActive(false);
        }
        if (controller.jump_particle)
        {
            walk_particle.SetActive(false);
            run_particle.SetActive(false);
            swim_particle.enableEmission = false;
            StartCoroutine(stop_particles());
            tread_particle.SetActive(false);
            jump_particle.SetActive(true);
        }
    }
    IEnumerator stop_particles()
    {
        yield return new WaitForSeconds(particle_time);
        swim_particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);

    }
    void get_data()
    {
        var ray = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit_data;
        if(Physics.Raycast(ray, out hit_data, 10))
        {
            if (hit_data.collider.tag == "cement")
            {
                ground_flag = 1;
            }
            else if (hit_data.collider.tag == "dirt")
            {
                ground_flag = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collision, 0.2f);
    }
}
