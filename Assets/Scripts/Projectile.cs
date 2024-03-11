using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private Vector3 direction = new Vector3(0, 0, 1);
    [SerializeField] private float lifetime = 2;
    [SerializeField] private Rigidbody body;

    private float currentLifetime;

    public event Action OnHit;

    private void Start()
    {
        body.velocity = direction * speed;
    }

    void Update()
    {
        currentLifetime += Time.deltaTime;
        if(currentLifetime >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            OnHit?.Invoke();
        }
    }
}
