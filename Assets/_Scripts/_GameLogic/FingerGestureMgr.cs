using System;
using UnityEngine;

public class FingerGestureMgr : MonoSingle<FingerGestureMgr>
{
    public SwipeRecognizer SwipeRecognizer;
    public DragRecognizer DragRecognizer;
    public TapRecognizer TapRecognizer;
    public ScreenRaycaster ScreenRaycaster;
    public FingerUpDetector FingerUpDetector;
    public FingerDownDetector FingerDownDetector;

    public event Action<SwipeGesture> SwipeEvent;
    public event Action<DragGesture> DragEvent;
    public event Action<TapGesture> TapEvent;
    public event Action<FingerUpEvent> FingerUpEvent;
    public event Action<FingerDownEvent> FingerDownEvent;

    public GameObject PickGameObject<T>(T Gesture, Vector2 ScreenPosition) where T: Gesture
    {
        return Gesture?.PickObject(ScreenRaycaster, ScreenPosition);
    }

    private void OnEnable()
    {
        SwipeRecognizer.OnGesture += SwipEventMethod;
        DragRecognizer.OnGesture += DragEventMethod;
        TapRecognizer.OnGesture += TapEventMethod;
        FingerUpDetector.OnFingerUp += FingerUpEventMethod;
        FingerDownDetector.OnFingerDown += FingerDownEventMethod;
    }

    private void OnDisable()
    {
        SwipeRecognizer.OnGesture -= SwipEventMethod;
        DragRecognizer.OnGesture -= DragEventMethod;
        TapRecognizer.OnGesture -= TapEventMethod;
        FingerUpDetector.OnFingerUp -= FingerUpEventMethod;
        FingerDownDetector.OnFingerDown -= FingerDownEventMethod;
    }

    private void SwipEventMethod(SwipeGesture swipeGesture)
    {
        SwipeEvent?.Invoke(swipeGesture);
    }

    private void DragEventMethod(DragGesture dragGesture)
    {
        DragEvent?.Invoke(dragGesture);
    }

    private void TapEventMethod(TapGesture tapGesture)
    {
        TapEvent?.Invoke(tapGesture);
    }

    private void FingerUpEventMethod(FingerUpEvent fingerUpEvent)
    {
        FingerUpEvent?.Invoke(fingerUpEvent);
    }

    private void FingerDownEventMethod(FingerDownEvent fingerDownEvent)
    {
        FingerDownEvent?.Invoke(fingerDownEvent);
    }
}
