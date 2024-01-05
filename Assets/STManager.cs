/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TweenLocalMove( Transform obj, Vector3 from, Vector3 to, float timer, EaseType easeType, Action onComplete = null)
    {
        STObj tST = obj.gameObject.AddComponent<STObj>();

        tST._sTMN = this;
        tST._tweenType = STObj.TweenType.localMove;
        tST._timer = 0;
        tST._timerLim = timer;
        tST._timerLimRate = 1 / timer;
        tST.from = from;
        tST.transform.localPosition = from;
        tST.to = to;

        tST.animCurve = _curveList[(int)easeType];
        tST.OnComplate = onComplete;

        _tweenObjList.Add(tST);
    }
}*/
