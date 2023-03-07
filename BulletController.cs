using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    Rigidbody2D bulletRigidbody;
    public float damage;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        bulletRigidbody.AddForce(transform.up * speed);
        Invoke("Disable", 4f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Disable()
    {
        gameObject.SetActive(false); //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().TakeDamage(damage);
            Invoke("Disable", 0.001f);
        }
    }

    private void OnDisable()
    {
        CancelInvoke(); 
    }
}
