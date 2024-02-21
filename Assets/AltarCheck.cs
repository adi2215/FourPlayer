using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltarCheck : MonoBehaviour
{
    public delegate void SlimeLost();
    public static SlimeLost onSlimeLost;

    public SaveData data;
    public Text[] text;
    public int AltarNum;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.gameObject.GetComponent<Player>();
        if (col.gameObject.tag == "Player" && player.haveSlime == true && AltarNum == player.numAltar)
        {
            player.objSlime.SetActive(false);
            player.haveSlime = false;

            data.slimes--;
            onSlimeLost?.Invoke();
            
            switch(col.gameObject.name)
            {
                case "Red":
                data.pointR += 1;
                text[0].text = data.pointR.ToString();
                break;
                case "Blue":
                data.pointB += 1;
                text[1].text = data.pointB.ToString();
                break;
                case "Purple":
                data.pointP += 1;
                text[2].text = data.pointP.ToString();
                break;
                case "Yellow":
                data.pointY += 1;
                text[3].text = data.pointY.ToString();
                break;
            }
        }
    }
}
