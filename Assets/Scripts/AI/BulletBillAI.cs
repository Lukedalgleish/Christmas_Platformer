using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBillAI : MonoBehaviour
{
    public float moveSpeed = -5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float move = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(move, 0, 0);
    }

}
