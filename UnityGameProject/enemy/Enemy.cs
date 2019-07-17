using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interact {

    PlayerManager playerManager;
    CharacterStats stats;

    public void Start()
    {
        playerManager = PlayerManager.instance;
        stats = GetComponent<CharacterStats>();
    }

    public override void Movetointeract()
    {
        base.Movetointeract();
        Combat playercombat = playerManager.player.GetComponent<Combat>();

        if (playercombat != null)
        {
            playercombat.Attack(stats);
        }
    }
}
