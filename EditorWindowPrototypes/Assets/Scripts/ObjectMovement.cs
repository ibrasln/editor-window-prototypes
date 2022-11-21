using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.velocity = new(moveSpeed * h, moveSpeed * v);
    }
}
