using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

[ Serializable] 
public enum ItemType
{
    Apple =1,
    Banana =2,
    Eggplant =3,
    Tomato =4,
    Orange =5,
    Cucumber =6,
    Chery =7,
}

public class ReactionOnHover : MonoBehaviour
{
    
    [SerializeField] private Material _mat;
    [SerializeField] private Color _OnSelectEmissionColor = Color.red;
    public event Action<ItemType> OnSelectItem;
    [SerializeField] private ItemType itemType;
    [SerializeField,Range(0.1f,3f)] private float _duration = 0.2f;
    private Vector3 origScale;
    private Vector3 maxScale;
    private TweenerCore<Vector3, Vector3, VectorOptions> _tweenerCore;

    private void Start()
    {
        origScale = transform.localScale;
        maxScale = origScale * 1.1f;
    }


    void OnMouseDown() 
    {
        Debug.Log($"OnMouseDown {itemType}");
        OnSelectItem?.Invoke(itemType);
    }
    void OnMouseEnter()
    {
        _mat.SetFloat("_UseEmission", 4f);
        _mat.SetColor("_EmissionColor", _OnSelectEmissionColor);

        transform.localScale = origScale;
        
        _tweenerCore = transform.DOScale(maxScale, _duration);
    }
    void OnMouseExit()
    {
        //_mat.SetFloat("_UseEmission", 0f);
        _mat.SetColor("_EmissionColor", Color.black);
    }
    
    
}
