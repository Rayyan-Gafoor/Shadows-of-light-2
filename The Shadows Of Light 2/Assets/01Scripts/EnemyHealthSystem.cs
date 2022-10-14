using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [Header("Health Stats")]
    public float max_health;
    public float current_health;
    public float detection_threshold;
    public LayerMask player_mask;

    public GameObject destroyed_enemy;
    public GameObject player;
    NewCombatSystem combat_system;
    // Start is called before the first frame update
    void Start()
    {
        combat_system = player.GetComponent<NewCombatSystem>();
        if (destroyed_enemy != null)
        {
            destroyed_enemy.SetActive(false);
        }
        current_health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(transform.position, detection_threshold, player_mask, QueryTriggerInteraction.UseGlobal))
        {
            combat_system.in_combat = true;
        }
        else
        {
            combat_system.in_combat = false;
        }
    }

    public void take_damage(float damage_amount)
    {
        current_health -= damage_amount;
        Debug.Log("Enemy Damaged");
        if (current_health < 0)
        {
            Destroy(gameObject);
            if (destroyed_enemy != null)
            {
                destroyed_enemy.SetActive(true);
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, detection_threshold);
    }
}
