using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpittingFlowerAI : MonoBehaviour
{
    private float riseTimeDuration = 1f;
    private float riseTimeRemaining;
    private float fallTimeDuration = 3f;
    private float fallTimeRemaining;
    private Vector3 startPosition;
    public float moveSpeedX;
    private float moveSpeedY = 4;

    void Start()
    {
        startPosition = transform.position;
        riseTimeRemaining = riseTimeDuration;
        fallTimeRemaining = fallTimeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        float moveLeft = moveSpeedX * Time.deltaTime;
        float moveUp = moveSpeedY * Time.deltaTime;

        if(riseTimeRemaining >= 0)
        {
            riseTimeRemaining -= Time.deltaTime;
            transform.position += new Vector3(moveLeft, moveUp, 0);
        }
        else
        {
            fallTimeRemaining -= Time.deltaTime;
            transform.position += new Vector3(0, -moveUp, 0);
            if (fallTimeRemaining <= 0) 
            {
                ResetState();
            }
        }
    }

    private void ResetState()
    {
        transform.position = startPosition;
        riseTimeRemaining = riseTimeDuration;
        fallTimeRemaining = fallTimeDuration;
    }
}
