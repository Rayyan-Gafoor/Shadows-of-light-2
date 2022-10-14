using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerController : MonoBehaviour
{
    public float enemy_damage;
    public GameObject player;

    PlayerHealth player_health;

    // Start is called before the first frame update
    void Start()
    {
        player_health = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Lazer Controller- Contact with player");
            player_health.take_damage(enemy_damage);
        }
    }
}
