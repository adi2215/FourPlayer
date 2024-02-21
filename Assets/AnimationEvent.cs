using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public UnityEvent OnAttackPerformed;

    public void TriggerAttack()
    {
        OnAttackPerformed?.Invoke();
    }

}
