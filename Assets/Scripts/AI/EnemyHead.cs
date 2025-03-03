using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    public PlayerController1 player;
    public Collider2D playersCollider;
    public GameObject parentGameObject;
    
    // only physics is being applied to the player so its okay to use OnTriggerEnter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playersCollider)
        {
            player.Jump();
            parentGameObject.SetActive(false);    
        }
    }
}
