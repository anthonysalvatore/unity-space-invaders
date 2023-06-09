using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecticle : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public System.Action destroyed;

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        destroyed.Invoke();
        Destroy(gameObject);
    }
}
