using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFeedBack : MonoBehaviour
{
    public GameObject run_particle;
    public GameObject walk_particle;
    public GameObject jump_particle;
    public GameObject tread_particle;
    public ParticleSystem swim_particle;
    public GameObject swim_obj;
    
    ThirdPersonCharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<ThirdPersonCharacterController>();
        swim_particle = swim_obj.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.walking_particle)
        {
            walk_particle.SetActive(true);
            run_particle.SetActive(false);
            StartCoroutine(stop_particles());
            tread_particle.SetActive(false);
            jump_particle.SetActive(false);
        }
        if (controller.running_particle)
        {
            walk_particle.SetActive(false);
            run_particle.SetActive(true);
            StartCoroutine(stop_particles());
            tread_particle.SetActive(false);
            jump_particle.SetActive(false);
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
            StartCoroutine(stop_particles());
            tread_particle.SetActive(true);
            jump_particle.SetActive(false);
        }
        if (controller.jump_particle)
        {
            walk_particle.SetActive(false);
            run_particle.SetActive(false);
            StartCoroutine(stop_particles());
            tread_particle.SetActive(false);
            jump_particle.SetActive(true);
        }
    }
    IEnumerator stop_particles()
    {
        yield return new WaitForSeconds(1.5f);
        swim_particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);

    }
}
