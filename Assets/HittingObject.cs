using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HittingObject : MonoBehaviour
{
    private Animator anim;
    public Player player;
    public Transform circleOrigin;
    public float radius;
    public SaveData data;

    
    public GameObject zone;

    public GameObject[] bananPrefab;

    public Text[] text;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
    }

    private void Start()
    {
        player.OnShoot += Player_OnShoot;
    }

    private void Player_OnShoot(object sender, Player.OnShootEventsArgs e)
    {
        anim.SetTrigger("Hit");
        DetectColliders();
    }

    public void DetectColliders()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            BananCode banan;
            if(banan = collider.GetComponent<BananCode>())
            {
                banan.GetHit();
                SpawnBanan.instance.SpawnBanans(zone.GetComponent<Collider2D>(), bananPrefab[Random.Range(0, bananPrefab.Length - 1)]);
                switch(player.name)
                {
                    case "Red":
                    data.pointR += banan.Points;
                    text[0].text = data.pointR.ToString();
                    break;
                    case "Blue":
                    data.pointB += banan.Points;
                    text[1].text = data.pointB.ToString();
                    break;
                    case "Purple":
                    data.pointP += banan.Points;
                    text[2].text = data.pointP.ToString();
                    break;
                    case "Yellow":
                    data.pointY += banan.Points;
                    text[3].text = data.pointY.ToString();
                    break;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

}
