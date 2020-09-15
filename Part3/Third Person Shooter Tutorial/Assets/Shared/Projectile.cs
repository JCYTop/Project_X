﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToLive;
    [SerializeField] private float damage;

    private void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Hit! {other.name}");
    }
}