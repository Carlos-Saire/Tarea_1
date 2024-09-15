using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStaticController : MonoBehaviour
{
    private GameObject Objetive;
    [SerializeField] private GameObject Incio;
    private Vector3 Movi;
    [SerializeField] private float Speed;
    private Vector3 Velocity = Vector3.zero;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private float life;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Objetive = collision.gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bulletP"))
        {
            --life;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Objetive = null;
        }
    }

    private void Update()
    {
        if (Objetive != null)
        {
            Movi = Vector3.SmoothDamp(transform.position, Objetive.transform.position, ref Velocity, Speed);
            transform.position = new Vector3(Movi.x, Movi.y, transform.position.z);
        }
        else
        {
            Movi = Vector3.SmoothDamp(transform.position, Incio.transform.position, ref Velocity, Speed);
            transform.position = new Vector3(Movi.x, Movi.y, transform.position.z);
        }

        scrollbar.size = Mathf.Clamp01(life / 10); 
    }
}
