using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float enemy_damage;
    public Transform player;
    public float move_speed;
    public GameObject destroyed_prefab;
    PlayerHealth player_health;
    Rigidbody rb;
    Vector3 movedirection;

    private void Start()
    {
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
            Instantiate(destroyed_prefab, transform.position, Quaternion.identity);

            
           // Destroy(gameObject,0.2f);
        }
        else if (other.tag != "Enemy")
        {
            Instantiate(destroyed_prefab, transform.position, Quaternion.identity);
           //Destroy(gameObject,0.2f);
        }
    }
    void projectile_behaviour()
    {
        movedirection = (player.transform.position - transform.position).normalized * move_speed;
        rb.velocity = new Vector3(movedirection.x, movedirection.y, movedirection.z);
    }
 
}
