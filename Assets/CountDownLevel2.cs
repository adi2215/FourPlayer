using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownLevel2 : MonoBehaviour
{
    [SerializeField] private Image _time;
    [SerializeField] private Text _timeText;
    public SaveData data;
    public float _currentTime;
    public float _duration;
    private bool win = false;
    public Transform Menu;
    public Text textWin;

    private void Start() => Lets();
    public void Lets()
    {
        _currentTime = _duration;
        _timeText.text = _currentTime.ToString();
        StartCoroutine(CountdownTime());
    }

    private IEnumerator CountdownTime () {
        while(_currentTime >= 0) {
            _time.fillAmount = Mathf.InverseLerp(0, _duration, _currentTime);
            _timeText.text = _currentTime.ToString();
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }
        yield return null;
        _currentTime = _duration;
        TimesEnd();
    }

    private void TimesEnd()
    {
        if (!win)
        {
            int winner = Math.Max(Math.Max(data.pointB, data.pointR), Math.Max(data.pointP, data.pointY));
            Menu.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
            win = true;
            if ((winner == data.pointB && (winner == data.pointR || winner == data.pointP || winner == data.pointY)) || 
            (winner == data.pointR && (winner == data.pointP || winner == data.pointY)) || winner == data.pointP && winner == data.pointY)
                textWin.text = "Draw";

            else if (winner == data.pointB)
                textWin.text = "Blue";
            
            else if (winner == data.pointR)
                textWin.text = "Red";

            else if (winner == data.pointP)
                textWin.text = "Purple";

            else if (winner == data.pointY)
                textWin.text = "Yellow";
        }
    }
}

