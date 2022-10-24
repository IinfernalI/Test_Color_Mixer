using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class Cap2 : MonoBehaviour
{
    [SerializeField] private Vector3 capOpen;
    [SerializeField] private Vector3 capClose;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _duration = 2.5f;
    private TweenerCore<Quaternion, Vector3, QuaternionOptions> _tweenerCore;
    public bool isOpen;
    
    [ContextMenu("TestSlapa")]
    public void Test()
    {
        Rotate(isOpen);
        isOpen = !isOpen;
    }
    public void Rotate(bool toOpen, float duration = -1)
    {
        
        Vector3 destination = toOpen ? capOpen : capClose;
        float dur = duration < 0f ? _duration : duration;
        
        _tweenerCore?.Kill();
        _tweenerCore = _transform.DOLocalRotate(destination, dur).SetEase(Ease.OutBounce);
    }
}