using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemyController : MonoBehaviour
{
    private readonly float _speedLaser = 8f;

    void Update()
    {
        transform.Translate(0, -1 * _speedLaser*Time.deltaTime, 0);

        Destroy(this.gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(СonstantsScript.PLAYER))
        {
            Destroy(gameObject);
        }
    }
}
