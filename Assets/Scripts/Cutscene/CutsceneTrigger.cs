using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    public PlayableAsset cutscene;
    public bool hasPlayed = false;
    public GameObject border;
 
    void OnTriggerEnter2D(Collider2D collid)
    {
        if (!hasPlayed && collid.gameObject.tag == "Player")
        {
            StartCoroutine(StartCutscene());
            border.SetActive(false);
        }
    }
 
    IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(.1f);
 
        hasPlayed = true;
        timeline.playableAsset = cutscene;
        timeline.Play();
    }
}
