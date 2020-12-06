using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector2 velocity;

    Rigidbody2D rigid2D;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        velocity = new Vector2(2f, 0f);
    }

    void FixedUpdate()
    {
    }

    void Move(float key)
    {
    }

    void OnCollitionEnter2D(Collider other)
    {

    }
}
