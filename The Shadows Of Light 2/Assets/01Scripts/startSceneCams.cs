using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSceneCams : MonoBehaviour
{
    public float time;
    [Header("Landmark Cams")]
    public GameObject lm_cam1;
    public GameObject lm_cam2;
    public GameObject lm_cam3;
    public GameObject lm_cam4;
    public GameObject lm_cam5;

    [Header("NPC Cams")]
    public GameObject NPC_cam1;
    public GameObject NPC_cam2;
    public GameObject NPC_cam3;
    public GameObject NPC_cam4;
    public GameObject NPC_cam5;

    [Header("Dolly Cam")]
    public GameObject dolly_cam;

    [Header("NPC Holders")]
    public GameObject NPC_figures;

    //public GameObject audio_obj;

    // Start is called before the first frame update
    void Start()
    {
        lm_cam1.SetActive(true);
        lm_cam2.SetActive(false);
        lm_cam3.SetActive(false);
        lm_cam4.SetActive(false);
        lm_cam5.SetActive(false);

        NPC_cam1.SetActive(false);
        NPC_cam2.SetActive(false);
        NPC_cam3.SetActive(false);
        NPC_cam4.SetActive(false);
        NPC_cam5.SetActive(false);

        dolly_cam.SetActive(false);
        StartCoroutine(camera_start_scene());
    }

 
    IEnumerator camera_start_scene()
    {

        yield return new WaitForSeconds(time);
        lm_cam1.SetActive(false);
        lm_cam2.SetActive(true);
        yield return new WaitForSeconds(time);
        lm_cam2.SetActive(false);
        lm_cam3.SetActive(true);
        yield return new WaitForSeconds(time);

        lm_cam3.SetActive(false);
        lm_cam4.SetActive(true);
        yield return new WaitForSeconds(time);

        lm_cam4.SetActive(false);
        lm_cam5.SetActive(true);
        yield return new WaitForSeconds(time);

        lm_cam5.SetActive(false);
        NPC_cam1.SetActive(true);
        yield return new WaitForSeconds(time);

        NPC_cam1.SetActive(false);
        NPC_cam2.SetActive(true);
        yield return new WaitForSeconds(time);

        NPC_cam2.SetActive(false);
        NPC_cam3.SetActive(true);
        yield return new WaitForSeconds(time);

        NPC_cam3.SetActive(false);
        NPC_cam4.SetActive(true);
        yield return new WaitForSeconds(time);

        NPC_cam4.SetActive(false);
        NPC_cam5.SetActive(true);

        yield return new WaitForSeconds(time*2);
        NPC_cam5.SetActive(false);
        NPC_figures.SetActive(false);
        dolly_cam.SetActive(true);
        yield return new WaitForSeconds(48f);
        dolly_cam.SetActive(false);
        //audio_obj.SetActive(false);
    }
}
