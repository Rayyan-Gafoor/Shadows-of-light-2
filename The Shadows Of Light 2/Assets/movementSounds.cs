using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementSounds : MonoBehaviour
{
    public AudioSource source;

    [Header("Walk Clips")]
    public AudioClip[] walk_clips;

    [Header("Run Clips")]
    public AudioClip[] run_clips;

    [Header("Swim Clips")]
    public AudioClip[] swim_clips;

    [Header("Idle Clips")]
    public AudioClip[] idle_clips;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// Play Sound Event Functions
    void steps()
    {
        AudioClip clip = get_walk_clip();
        source.PlayOneShot(clip);
    }
    void swim_stroke()
    {
        AudioClip clip = get_swim_clip();
        source.PlayOneShot(clip);
    }
    void run_step()
    {
        AudioClip clip = get_run_clip();
        source.PlayOneShot(clip);
    }
    void idle_talk()
    {
        /*AudioClip clip = get_idle_clip();
        source.PlayOneShot(clip);*/
    }
    ///Get Functions for Audio
    private AudioClip get_walk_clip()
    {
        int index = Random.Range(0, walk_clips.Length - 1);
        return walk_clips[index];
    }
    private AudioClip get_run_clip()
    {
        int index = Random.Range(0, run_clips.Length - 1);
        return run_clips[index];
    }
    private AudioClip get_swim_clip()
    {
        int index = Random.Range(0, swim_clips.Length - 1);
        return swim_clips[index];
    }
    private AudioClip get_idle_clip()
    {
        int index = Random.Range(0, idle_clips.Length - 1);
        return idle_clips[index];
    }
}
