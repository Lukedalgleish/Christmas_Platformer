using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;

    public static bool playerDead { get; private set; }

    public GameObject PlayerObject;
    public GameObject playerDeathObject;

    private Rigidbody2D deathRB;

    private Vector3 respawnPos = new Vector3(0, 0, 0);

    void Start()
    {
        // Check if an instance of the singleton already exists
        if (Instance == null)
        {
            // If not, set the instance to this instance
            Instance = this;

            // Optional: Prevent this object from being destroyed when a new scene loads
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists and it's not this, destroy this object
            Destroy(gameObject);
        }

        deathRB = playerDeathObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(playerDead == true)
        {
            PlayerDeathState();
            StartCoroutine(RespawnPlayerCoroutine());
        }
        else { return; }
    }

    public void SetPlayerDead()
    {
        playerDead = true;

        Debug.Log("Player is now dead!");
    }

    private void PlayerDeathState()
    {
        PlayerObject.SetActive(false);
        playerDeathObject.transform.position = PlayerObject.transform.position;
        playerDeathObject.SetActive(true);
        deathRB.AddForce(transform.up * 5, ForceMode2D.Impulse);
    }

    IEnumerator RespawnPlayerCoroutine()
    {
        playerDead = false;

        Debug.Log("Timer started!");
        
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        playerDeathObject.SetActive(false);
        PlayerObject.transform.position = respawnPos;
        PlayerObject.SetActive(true);

        Debug.Log("Timer ended after 3 seconds!");
    }
}


