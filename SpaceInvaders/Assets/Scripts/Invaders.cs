using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    [SerializeField] private int rows = 5;
    [SerializeField] private int columns = 11;
    [SerializeField] private AnimationCurve speed;

    [SerializeField] private Invader[] prefabs;

    private Vector3 direction = Vector3.right;

    public int amountKilled { get; private set; }
    public int totalInvaders => rows * columns;
    public float percentKilled => (float)amountKilled / (float)totalInvaders;

    private void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            float spacing = 2.0f;
            float width = spacing * columns - 1;
            float height = spacing * rows - 1;

            Vector3 centering = new Vector3(-width/2, -height/2, 0);
            Vector3 rowPostion = new Vector3(centering.x, centering.y + row * spacing, 0);

            for (int col = 0; col < columns; col++)
            {
                Invader invader = Instantiate(prefabs[row], transform);
                invader.killed += InvaderKilled;
                Vector3 position = rowPostion;
                position.x += col * spacing;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Update()
    {
        transform.position += direction * speed.Evaluate(percentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy) { continue; }

            if (direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f))
            {
                AdvanceRow();
            }
            else if (direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        direction.x *= -1.0f;

        Vector3 position = transform.position;
        position.y += -1.0f;
        transform.position = position;
    }

    private void InvaderKilled()
    {
        amountKilled++;
    }
}
