using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DotweenHelper : MonoBehaviour
{
    public bool scaleOnStart;
    [SerializeField] float showTime=0.3f, hideTime=0.2f;
    [SerializeField] Ease showEase=Ease.OutBack, hideEase=Ease.InBack;
    [SerializeField] Transform tweenGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if (scaleOnStart)
        {
            if (tweenGo == null) { tweenGo = transform; }
            tweenGo.localScale = Vector3.zero;
            tweenGo.DOScale(1, showTime).SetEase(showEase);
        }
    }
}
