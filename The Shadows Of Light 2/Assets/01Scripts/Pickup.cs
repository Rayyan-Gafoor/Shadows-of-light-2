using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool can_pickup;
    public GameObject ui, lore;
    //public GameObject menu_page;
    public GameObject transcript;
    //public GameObject menu;
    [Header("Materials")]
    public Material normal_mat, dissolve_mat;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        //menu.SetActive(false);
        //menu_page.SetActive(false);
        transcript.SetActive(false);
        rend = this.GetComponent<Renderer>();
        rend.enabled = true;
        rend.material = normal_mat;
        can_pickup = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && can_pickup)
        {
            StartCoroutine(pick_up());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            can_pickup = true;
            ui.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            can_pickup = true;
            ui.SetActive(false);
        }
    }
    IEnumerator pick_up()
    {
        
        rend.material = dissolve_mat;
        transcript.SetActive(true);
        ui.SetActive(false);
        can_pickup = false;
        lore.SetActive(true);
        yield return new WaitForSeconds(2);
        //menu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
