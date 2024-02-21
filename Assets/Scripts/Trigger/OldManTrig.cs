using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManTrig : MonoBehaviour
{
    public LetGo contextOn;

    public LetGo contextOff;

    public bool playerInRange;

    public DialogTrigger trigger;

    public bool currentPlayer = true;

    public GameObject contextClue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && !DialogManager.isActive)
        {
            trigger.StartDialog();
            contextClue.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !DialogManager.isActive)
        {
            contextOn.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            contextOff.Raise();
            playerInRange = false;
        }
            
    }
}
