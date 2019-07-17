using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour {

    public Transform player;
    public Transform teleportlocation;

    void OnTriggerEnter(Collider other)
    {
        GameObject.Find("player").GetComponent<NavMeshAgent>().enabled = false;
            player.transform.position = teleportlocation.transform.position;
        GameObject.Find("player").GetComponent<NavMeshAgent>().enabled = true;
    }
}
