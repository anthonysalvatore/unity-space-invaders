using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    [SerializeField] private int rows = 5;
    [SerializeField] private int columns = 11;

    [SerializeField] private Invader[] prefabs;

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
                Vector3 position = rowPostion;
                position.x += col * spacing;
                invader.transform.localPosition = position;
            }
        }
    }
}
