using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    [SerializeField] private float Speed;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private float life;
    private Rigidbody2D RB2D;
    private bool removelife = false;
    public GameObject losue;
    public GameObject win;

    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        scrollbar.size = life / 10;
    }

    public void Horizontal(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<float>();
    }

    public void Vertical(InputAction.CallbackContext context)
    {
        vertical = context.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        RB2D.velocity = new Vector2(horizontal * Speed, vertical * Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            removelife = true;
            RemoveLife();
            print("Entro");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            removelife = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("win"))
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void RemoveLife()
    {
        if (removelife==true)
        {
            --life;
            Invoke("RemoveLife", 0.5f);
            if(life <= 0)
            {
                losue.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

}
