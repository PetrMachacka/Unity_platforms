using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public float speed = 5f;
    public float extend = 10;
    private Vector3 start;

    public enum direction
    {
        right,
        left
    }
    public direction Direction = direction.right;
    private void Start()
    {
        start = platform.position;
    }
    void Update()
    {
        if (Direction == direction.right)
        {
            platform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Direction == direction.left)
        {
            platform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < start.x || transform.position.x > start.x + extend)
        {
            ChangeDirection();
        }
    }
    private void ChangeDirection()
    {
        Direction = (Direction == direction.right) ? direction.left : direction.right;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            ChangeDirection();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            collision.gameObject.transform.SetParent(null);
    }
}
