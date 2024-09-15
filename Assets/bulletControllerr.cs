using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControllerr : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float Speed;
    public float Xdirection = 0;
    public float Ydirection = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Xdirection * Speed, Ydirection * Speed);
    }
}
