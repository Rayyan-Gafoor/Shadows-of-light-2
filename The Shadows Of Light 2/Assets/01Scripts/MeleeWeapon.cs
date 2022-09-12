using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject player;
    public float attack_damage;

    [Header("Object Layers")]
    public LayerMask destructable;
    
    //refs
    EnemyHealthSystem enemy_health;
    DestroyableObject obstruction;
    CombatSystem combat_system;
    
    void Start()
    {
        combat_system = player.GetComponent<CombatSystem>();
        attack_damage = combat_system.attack_damage;
    }

    
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
        if (other.tag == "Destroyable")
        {
            obstruction = other.gameObject.GetComponent<DestroyableObject>();
            obstruction.take_damage(attack_damage);
        }
    }
}
