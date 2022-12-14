using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float enemy_damage;
    public Transform player;
    public float move_speed;
    public GameObject prefab;
    public GameObject destroyed_prefab;
    GameObject this_obj;
    PlayerHealth player_health;
    Rigidbody rb;
    Vector3 movedirection;

    private void Start()
    {
        prefab.SetActive(true);
        destroyed_prefab.SetActive(false);
        this_obj = this.gameObject;
        player = GameObject.Find("Player").transform;
        player_health = player.GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody>();
        projectile_behaviour();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Contact with player");
            player_health.take_damage(enemy_damage);
            
            destroyed_prefab.SetActive(true);
            prefab.SetActive(false);

        }
        else if (other.tag != "Enemy" && other.tag!="EnemyWeapon")
        {
            
            destroyed_prefab.SetActive(true);
            prefab.SetActive(false);

        }
    }
    void projectile_behaviour()
    {
        movedirection = (player.transform.position - transform.position).normalized * move_speed;
        rb.velocity = new Vector3(movedirection.x, movedirection.y, movedirection.z);
    }
 
}
