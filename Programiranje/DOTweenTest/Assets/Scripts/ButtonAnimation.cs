using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public enum AnimationType
{
    Pop,
    SlideDown,
    Shake,
    Punch
}

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField] AnimationType animationType;
    [SerializeField] UnityEvent OnAnimationFinished;

    RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void PlayAnimation()
    {
        switch(animationType)
        {
            case AnimationType.Pop:
                PlayPopAnimation(); 
                break;

            case AnimationType.SlideDown:
                PlaySlideAnimation();
                break;

            case AnimationType.Shake:
                PlayShakeAnimation();
                break;

            case AnimationType.Punch:
                PlayPunchAnimation();
                break;
        }
    }

    private void PlayPopAnimation()
    {
        _rectTransform.DOScale(new Vector2(0.8f, 0.8f), 0.3f).onComplete = () =>
            _rectTransform.DOScale(new Vector2(1f, 1f), 0.3f).onComplete = () =>
                OnAnimationFinished.Invoke();
    }

    private void PlaySlideAnimation()
    {
        _rectTransform.DOAnchorPosY(-12, 0.3f).onComplete = () =>
            _rectTransform.DOAnchorPosY(0, 0.3f).onComplete = () =>
                OnAnimationFinished.Invoke();
    }

    private void PlayShakeAnimation()
    {
        _rectTransform.DOShakeAnchorPos(0.3f, 30).onComplete = () =>
                OnAnimationFinished.Invoke();
    }

    private void PlayPunchAnimation()
    {
        _rectTransform.DOPunchAnchorPos(new Vector2(-2f, 2f), 0.3f).onComplete = () =>
             OnAnimationFinished.Invoke();
    }
}
