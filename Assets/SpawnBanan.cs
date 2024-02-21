using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBanan : MonoBehaviour
{
    public static SpawnBanan instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SpawnBanans(Collider2D col, GameObject obj)
    {
        int count = Random.Range(1, 3);
        for (int i = 1; i <= count; i++)
            Instantiate(obj, GetRandomPos(col), Quaternion.identity);
        
    }

    private Vector2 GetRandomPos(Collider2D collider, float offset = 0.5f)
    {
        Bounds collBounds = collider.bounds;

        Vector2 minBounds = new Vector2(collBounds.min.x + offset, collBounds.min.y + offset);
        Vector2 maxBounds = new Vector2(collBounds.max.x - offset, collBounds.max.y - offset);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);

        return new Vector2(randomX, randomY);
    }
}
