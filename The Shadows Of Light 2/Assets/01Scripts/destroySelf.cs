using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(setactive());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator setactive()
    {
        yield return new WaitForSeconds(7f);
        this.gameObject.SetActive(false);
    }
}
