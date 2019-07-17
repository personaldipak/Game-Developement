using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public GameObject effect;
    public float multipler = 2f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider Player)
    {
        Instantiate(effect, transform.position, transform.rotation);

        PlayerStats stats = Player.GetComponent<PlayerStats>();
        stats.CurrentHealth *= multipler;

        Destroy(gameObject);

    }
}
