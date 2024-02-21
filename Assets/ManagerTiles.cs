using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerTiles : MonoBehaviour
{
    private List<int> randomNumbers = new List<int>();

    public List<TileExplode> tiles = new List<TileExplode>();

    private bool win = false;

    public Transform Menu;
    public Text textWin;

    private void Start()
    {
        Invoke("StartExplode", 2f);
    }

    private void StartExplode() => StartCoroutine(Explode());

    private IEnumerator Explode()
    {
        if (win)
        {
            yield return null;
        }

        Debug.Log("Explode");
        RandomNumber();
        
        for (int i = 0; i < tiles.Count; i++)
            if (!randomNumbers.Contains(i))
                tiles[i].ExplodeAnim();
        
        randomNumbers.Clear();

        yield return new WaitForSeconds(4f);

        CheckPlayers();

        yield return new WaitForSeconds(5f);

        StartCoroutine(Explode());
    }

    private void CheckPlayers()
    {
        GameObject[] checkPlayers = GameObject.FindGameObjectsWithTag("Player");

        if (checkPlayers.Length == 0)
        {
            Menu.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
            textWin.text = "Draw";
        }

        if (checkPlayers.Length == 1)
        {
            win = true;
            Menu.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
            textWin.text = checkPlayers[checkPlayers.Length - 1].name;
        }
    }

    private void RandomNumber()
    {
        for (int i = 0; i < Random.Range(3, 6); i++)
        {
            int randomNumber = Random.Range(1, tiles.Count);
            randomNumbers.Add(randomNumber);
        }
    }
}
