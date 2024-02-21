using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] private Ghoust ghostSpeed;
    [SerializeField] private Image _time;
    [SerializeField] private Text _timeText;
    public float _currentTime;
    public float _duration;

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
        ghostSpeed.speed += 1f;
    }
}
