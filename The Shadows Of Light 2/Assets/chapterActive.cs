using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapterActive : MonoBehaviour
{

    public GameObject chapter_ui;
    public float ui_active_time;
    public bool can_activate = true;
    private void Start()
    {
        can_activate = true;
        chapter_ui.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player" && can_activate == true)
        {
            chapter_ui.SetActive(true);
            can_activate = false;
            StartCoroutine(activated());
        }
    }

    IEnumerator activated()
    {
        yield return new WaitForSeconds(ui_active_time);
        chapter_ui.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
