using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject player;
    public float attack_damage;
    EnemyHealthSystem enemy_health;
    CombatSystem combat_system;
    // Start is called before the first frame update
    void Start()
    {
        combat_system = player.GetComponent<CombatSystem>();
        attack_damage = combat_system.attack_damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy_health = other.gameObject.GetComponent<EnemyHealthSystem>();
            enemy_health.take_damage(attack_damage);
        }
    }
}
