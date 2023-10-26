using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private float _speedEnemy = 0.5f;
    void Update()
    {
        transform.Translate(0, -1 * _speedEnemy * Time.deltaTime, 0);
    }
}
