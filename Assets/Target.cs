using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 2;
    public GameObject effect;

    private void Defeated()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private float distance;
    public float speed;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hero");
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
