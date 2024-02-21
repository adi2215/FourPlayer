using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananCode : MonoBehaviour
{
    public GameObject objEffect;

    private SpawnBanan spawn;

    public int Points;

    private void Start()
    {
        Destroy(gameObject, Random.Range(5f, 30f));
    }

    public void GetHit()
    {
        GameObject effect = Instantiate(objEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
        Destroy(effect, 1f);
    }
}
