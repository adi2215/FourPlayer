using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public Transform target;

    public Transform Scene_Target;

    public float something;

    private bool LetCam = false;

    public Vector2 maxPos;
    public Vector2 minPos;

    public bool PlayerTrig = false;

    private void FixedUpdate()
    {
        if (transform.position != target.position && !LetCam)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, -10f);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, something);
        }

        else if (LetCam)
        {
            Vector3 targetScene = new Vector3(Scene_Target.position.x, Scene_Target.position.y, -10f);

            transform.position = Vector3.Lerp(transform.position, targetScene, 0.015f);
        }
    }

    public void CutSceneCam()
    {
        PlayerTrig = true;
        StartCoroutine(StartCountdown());
    }

    public void CutSceneCamReturn()
    {
        StartCoroutine(StartCountUp());
    }

    public IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(.3f);
        LetCam = true;
    }   

    public IEnumerator StartCountUp()
    {
        yield return new WaitForSeconds(.3f);
        LetCam = false;
        PlayerTrig = false;
    }   
}
