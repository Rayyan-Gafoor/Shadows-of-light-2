using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introVoiceOver : MonoBehaviour
{
    public AudioSource voice, ambience;
    public bool flag1, flag2;
    public float audio_timer;

    public float current_timer, duration, target_volume, start_vol;
    // Start is called before the first frame update
    void Start()
    {
        flag1 = true;
        flag2 = false;
        current_timer = 0;
        start_vol = ambience.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag1 == true)
        {
            StartCoroutine(decrease_audio());
        }
        if (flag2 == true && current_timer<duration)
        {
            current_timer += Time.deltaTime;
            ambience.volume = Mathf.Lerp(start_vol, target_volume, current_timer / duration);
           
        }
    }

    IEnumerator decrease_audio()
    {
        yield return new WaitForSeconds(audio_timer);
        flag2 = true;
            
    } 
}
