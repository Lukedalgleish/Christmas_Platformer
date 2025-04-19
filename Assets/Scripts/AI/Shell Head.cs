using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellHead : MonoBehaviour
{
    public PlayerController1 player;
    private Collider2D playersCollider;
    public GameObject parentGameObject;
    public ShellAI shellAIScript;

    // only physics is being applied to the player so its okay to use OnTriggerEnter

    private void Start()
    {
        playersCollider = player.GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playersCollider)
        {
            player.Jump();
            shellAIScript.PlayerHitsShell();
        }
    }
}
