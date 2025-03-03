using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    private float timeBeforeDeactivated = 0.5f;

    void Update()
    {
        timeBeforeDeactivated -= Time.deltaTime;
        if (timeBeforeDeactivated <= 0)
        {
            gameObject.SetActive(false);
            timeBeforeDeactivated = 0.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with an object with the tag "enemy", this will be executed.
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

    }
}
