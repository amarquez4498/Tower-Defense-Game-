using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarShellController : MonoBehaviour
{
    public float speed;
    Rigidbody2D bulletRigidbody;
    public float damage;

    public float radius;
    public LayerMask enemyMask;

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
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius, enemyMask);
            foreach(Collider2D col in hit)
                collision.GetComponent<EnemyController>().TakeDamage(damage);
            Invoke("Disable", 0.001f);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
