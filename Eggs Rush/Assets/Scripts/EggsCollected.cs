using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EggsCollected : MainEgg
{


    private void Start()
    {
       

        //Animation for the collected ring
        transform.DOScale(Vector3.one * 1.2f, 0.20f).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOScale(Vector3.one, 0.20f).SetEase(Ease.Linear);
        });
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }



}