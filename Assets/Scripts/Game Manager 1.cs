using System.Collections;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;

    public static bool playerDead { get; private set; }
    public static int coinCounter { get; private set; }
    public static int lifeCounter { get; private set; }
    public static int highscoreCounter { get; private set; }
    public static int currentPlayerHealth { get; private set; }

    private const int MAX_PLAYER_HEALTH = 100;
    private const int RESET_LIFE_COUNTER = 3;
    private const int RESET_HIGHSCORE_COUNTER = 0;
    private const int RESET_COIN_COUNTER = 0;


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

        // Temp until I create a save/load system
        currentPlayerHealth = 100;
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
    }

    public void PlayerTakesDamage()
    {
        currentPlayerHealth -= 50;
        if (currentPlayerHealth <= 0)
        {
            PlayerDeathState();
        }
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

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        playerDeathObject.SetActive(false);
        PlayerObject.transform.position = respawnPos;
        PlayerObject.SetActive(true);
    }
    public void AddCoin()
    {
        coinCounter += 1;
        //Debug.Log("Coin counter: " + coinCounter);
        if (coinCounter >= 100)
        {
            // Add a live
            AddLife();

            //Reset coin amount back to 0
            coinCounter = RESET_COIN_COUNTER;
        }
    }

    public void AddLife()
    {
        lifeCounter += 1;
        Debug.Log("Life counter: " + lifeCounter);
        
    }

    public void RemoveLife()
    {
        lifeCounter -= 1;
        Debug.Log("Life counter: " + lifeCounter);

        if (lifeCounter <= 0)
        {
            /* 
             * When the lifeCounter goes below 0 we want to:
             * Lifecounter re-verts back to 3 (Use "DEFAULT_LIFE_COUNTER").
             * The highscore needs to be decreased to 0
             */
            lifeCounter = RESET_LIFE_COUNTER;
            highscoreCounter = RESET_HIGHSCORE_COUNTER;
        }
    }

    public void AddScore()
    {
        /* 
         * Here we need to add score based on player action e.g. (Collecting coins, killing enemies etc...)
         * Not sure how we're setting this up yet but thats the idea!
         */

        highscoreCounter += 1;
        Debug.Log("Highscore counter: " + highscoreCounter);
    }


}


