using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateDoor : MonoBehaviour
{
    public GameObject deactivate, activate, frame;
    public bool activated;
    public int flag;
    public bool light_can_change = false;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        deactivate.SetActive(true);
        activate.SetActive(false);
        frame.SetActive(false);
        light_can_change = false;

}

// Update is called once per frame
void Update()
    {
        if (flag == 2)
        {
            activated = true;
        }
        if (activated)
        {
            deactivate.SetActive(false);
            activate.SetActive(true);
            frame.SetActive(true);
            light_can_change = true;
        }
    }
}
