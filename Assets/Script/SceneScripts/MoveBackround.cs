using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackround : MonoBehaviour
{
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float speed = 1f;
        transform.Translate(-1 * speed * Time.deltaTime,0, 0);
    }
}
