using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ghoust : MonoBehaviour
{
    public float speed = 5f;  // Adjust the speed as needed.
    public string targetTag = "Player";  // Tag of the characters you want the enemy to chase.

    private Transform target;
    public Countdown timer;
    public Transform Menu;
    public Text textWin;
    public GameObject prefabB;
    public GameObject ghoustPrefab;
    public List<GameObject> gm;
    public bool win = false;
    

    void Start()
    {
        // Find the initial target.
        FindTarget();
    }

    void Update()
    {
            // If the target is lost, find the closest one.
        
        FindTarget();

        // Move towards the target.
        MoveTowardsTarget();
    }

    void FindTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        if (targets.Length == 1 && !win)
        {
            Menu.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
            win = true;
            textWin.text = targets[0].name.ToString();
        }

        if (targets.Length > 0)
        {
            float shortestDistance = Mathf.Infinity;
            GameObject nearestTarget = null;

            foreach (GameObject potentialTarget in targets)
            {
                float distanceToTarget = Vector2.Distance(transform.position, potentialTarget.transform.position);

                if (distanceToTarget < shortestDistance)
                {
                    shortestDistance = distanceToTarget;
                    nearestTarget = potentialTarget;
                }
            }

            target = nearestTarget.transform;
        }
        else
        {
            target = null;
        }
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Instantiate(prefabB, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            speed = 1f;
            timer.Lets();
            switch(col.gameObject.name)
            {
                case "Red":
                gm[0].SetActive(true);
                break;
                case "Blue":
                gm[2].SetActive(true);
                break;
                case "Purple":
                gm[1].SetActive(true);
                break;
                case "Yellow":
                gm[3].SetActive(true);
                break;
            }
        }
        Debug.Log("f");
    }
}
