using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [Header("Health Stats")]
    public float max_health;
    public float current_health;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void take_damage(float damage_amount)
    {
        current_health -= damage_amount;
        if (current_health < 0)
        {
            Destroy(gameObject);
        }
    }
}
