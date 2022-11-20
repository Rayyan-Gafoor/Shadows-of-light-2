using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public GameObject Buttons;
    public GameObject credits;
    public GameObject Figure;
    public float start_time;

    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex==0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            close_game();
        }
    }

    public void start_game()
    {
        StartCoroutine(starting_newgame());
    }
    public void close_game()
    {
        Application.Quit();
    }
    public void credit_menu()
    {
        credits.SetActive(true);
        Buttons.SetActive(false);
        source.PlayOneShot(clip);
    }
    public void back()
    {
        credits.SetActive(false);
        Buttons.SetActive(true);
        source.PlayOneShot(clip);
    }

    IEnumerator starting_newgame()
    {
        Buttons.SetActive(false);
        Figure.SetActive(true);
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(start_time);
        SceneManager.LoadScene(1);
    }
}
