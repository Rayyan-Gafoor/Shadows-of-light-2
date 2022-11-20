using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finalScene : MonoBehaviour
{
    public GameObject thank_you;
    public GameObject exit_button;
    public GameObject continue_button;

    public float timer;
    public bool flag;

    public GameObject portal_obj;
    portalexit portal;

    // Start is called before the first frame update
    void Start()
    {
        portal = portal_obj.GetComponent<portalexit>();
        if (thank_you.activeSelf)
        {
            Debug.Log("mouse on");
           // Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }
        exit_button.SetActive(false);
        continue_button.SetActive(false);
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (thank_you.activeSelf && flag)
        {
            flag = false;
            StartCoroutine(voice_over());

        }
    }
    public void continue_game()
    {
        thank_you.SetActive(false);
        portal.cam_flag = false;
    }
    public void exit_mainmenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator voice_over()
    {
        Debug.Log("end Scene");
        yield return new WaitForSeconds(timer);
        exit_button.SetActive(true);
        continue_button.SetActive(true);
    }
}
