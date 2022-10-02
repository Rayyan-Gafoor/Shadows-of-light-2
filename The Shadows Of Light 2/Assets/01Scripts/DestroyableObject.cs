using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    [Header("Object Stats")]
    public float lifeline;
    public float current_lifeline;

    public GameObject destroyed_obj;

    // Start is called before the first frame update
    void Start()
    {
        destroyed_obj.SetActive(false);
        current_lifeline = lifeline;
    }

    public void take_damage(float damage_amount)
    {
        current_lifeline -= damage_amount;
        if (current_lifeline < 0)
        {
            //play animation of falling wall
            destroyed_obj.SetActive(true);
            Destroy(gameObject,0.2f);
        }
    }
}
