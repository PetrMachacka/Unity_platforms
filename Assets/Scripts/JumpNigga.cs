using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpNigga : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Rigidbody2D rb;
    public float jumpAmount = 10;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
        }
    }
}
