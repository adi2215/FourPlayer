using UnityEngine;

public class TileExplode : MonoBehaviour
{
    private Animator anim;
    public Transform trans;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void ExplodeAnim()
    {
        anim.Play("Explode");
        Invoke("ExplodEnd", 3.5f);
    }

    public void ExplodeTile()
    {
        foreach (Collider2D collider in Physics2D.OverlapBoxAll(trans.position, new Vector2(1.7f, 1.5f), 0))
        {
            Player player;

            if (player = collider.GetComponent<Player>())
            {
               player.TakeDamage(); 
            }
        }
    }

    private void ExplodEnd()
    {
        anim.Play("Nothing");
    }
}
