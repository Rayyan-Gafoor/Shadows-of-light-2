using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public float rotation_speed, movement_speed;
    public bool opening, can_open, opened;
    public float angle;
    public GameObject ui;
    public AudioSource source;
    public AudioClip door_clip;

    [SerializeField]
    Transform start, end;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = start.position;
        source.clip = door_clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && can_open)
        {
            opening = true;
            source.clip = door_clip;
            source.Play();
            ui.SetActive(false);
            can_open = false;
            opened = true;
        }
        if (opening)
        {
            open_door();
        }
    }
    void open_door()
    {
        StartCoroutine(stop_door());
        transform.position = Vector3.Lerp(transform.position, end.position, movement_speed * Time.deltaTime);
        
        transform.rotation= Quaternion.Lerp(transform.rotation, Quaternion.Euler(angle, -90, -90), Time.deltaTime * rotation_speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !opened)
        {
            ui.SetActive(true);
            can_open = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !opened)
        {
            ui.SetActive(false);
            can_open = false;
        }
    }
    IEnumerator stop_door()
    {
        yield return new WaitForSeconds(10);
        opening = false;
    }
}
