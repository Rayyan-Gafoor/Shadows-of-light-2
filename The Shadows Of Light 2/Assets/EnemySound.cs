using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;

    public float flag = 0;
    public float time_between_sounds = 7;
    void Update()
    {
        if (time_between_sounds > 0)
        {
            time_between_sounds -= Time.deltaTime;
        }
        if (time_between_sounds <= 0)
        {
            StartCoroutine(play_random());
            time_between_sounds = 7;
        }
    }

    IEnumerator play_random()
    {
        yield return new WaitForSeconds(0.1f);
        AudioClip clip = get_idle_clip();
        source.PlayOneShot(clip);
        flag = 1;
    }
    IEnumerator play_random2()
    {
        yield return new WaitForSeconds(7);
        AudioClip clip = get_idle_clip();
        source.PlayOneShot(clip);
        flag = 0;
    }
    private AudioClip get_idle_clip()
    {
        int index = Random.Range(0, clips.Length - 1);
        return clips[index];
    }
}
