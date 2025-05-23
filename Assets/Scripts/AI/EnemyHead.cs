using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    public PlayerController1 player;
    private Collider2D playersCollider;
    public GameObject parentGameObject;
    public GameObject shellGameObject;

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

            if (parentGameObject.name == "Turtle" && shellGameObject != null)
            {
                Debug.Log("You jumped on a turtle head, replacing with a shell");
                shellGameObject.transform.position = new Vector2(parentGameObject.transform.position.x, (parentGameObject.transform.position.y - 0.6f)) ;
                shellGameObject.SetActive(true);
            }
            parentGameObject.SetActive(false);    
        }
    }
}