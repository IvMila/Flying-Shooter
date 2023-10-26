using UnityEngine;

public class LaserMove : MonoBehaviour
{
    private readonly float _speed = 10f;

    private void Update()
    {
        transform.Translate(0, 1 * _speed * Time.deltaTime, 0);
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
