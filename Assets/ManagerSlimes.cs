using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSlimes : MonoBehaviour
{
    private GameObject[] numberSlimes;

    public SaveData data;

    public Collider2D col;

    public GameObject obj;

    private void Start()
    {
        numberSlimes = GameObject.FindGameObjectsWithTag("slime");
        data.slimes = numberSlimes.Length;
    }

    private void OnEnable() {
        AltarCheck.onSlimeLost += SlimeDicrease;
    }

    private void OnDisable() {
        AltarCheck.onSlimeLost -= SlimeDicrease;
    }

    private void SlimeDicrease()
    {
        if (data.slimes <= 4)
        {
            int count = Random.Range(4, 5);
            data.slimes += count;
            for (int i = 1; i <= count; i++)
                Instantiate(obj, GetRandomPos(col), Quaternion.identity);
        }
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
