using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    public Projecticle laserPrefab;

    private bool laserActive;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }

        transform.position += new Vector3(direction.x, 0, 0) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!laserActive) 
        {
            Projecticle projectile = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            laserActive = true;
        }
    }

    private void LaserDestroyed()
    {
        laserActive = false;
    }
}
