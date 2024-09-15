using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private LayerMask LayerInteractue; 
    [SerializeField] private float distancia; 
    [SerializeField] private float speed; 
    [SerializeField] private GameObject objetivo; 
    [SerializeField] private Scrollbar scrollbar; 
    private RaycastHit2D hit; 
    [SerializeField] private Vector2 direction;
    [SerializeField] private float life;
    private void FixedUpdate()
    {
        direction = (objetivo.transform.position - transform.position).normalized;
        hit = Physics2D.Raycast(transform.position, direction, distancia, LayerInteractue);
    }
    private void RaycastCheck()
    {
    }
    private void Update()
    {
        Move();
        scrollbar.size = life / 10;

    }
    public void SetObjetive(GameObject NewObjetivo)
    {
        objetivo = NewObjetivo;
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, objetivo.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bulletP"))
        {
            --life;
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                Destroy(this.gameObject);
            }   
        }
    }
}
