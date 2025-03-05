using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTurtleAI : MonoBehaviour
{
    public float moveSpeedX = -1f;
    public float moveSpeedY = 0.5f;
    public float speedIncrease = -2f;

    // Update is called once per frame
    void Update()
    {
        float moveLeft = moveSpeedX * Time.deltaTime;
        float moveUp = moveSpeedY * Time.deltaTime;
        

        if (transform.position.y <= -0.6)
        {
            transform.position += new Vector3(moveLeft, moveUp, 0);
        }
        else
        {
            float increaseXSpeed = speedIncrease * Time.deltaTime;
            transform.position += new Vector3((moveLeft + increaseXSpeed), 0, 0);
        }
    }
}
