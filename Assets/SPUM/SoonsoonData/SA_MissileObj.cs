/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_MissileObj : MonoBehaviour
{

    public SA_Unit _target;

    public float _speed;

    public float _timeForLim;

    public float _range;

    public bool _homing;

    public float _yPos;

    public float _yPosSave;

    public string tTag;

    public string MissileType;

    public float _timer;

    public float _timerForLim;

    Vector3 _startPos;

    Vector2 _endPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetInit()
    {
        _missileList.Clear();
        for(var i = 0; i < transform.childCount; i++)
        {
            GameObject tObj = transform.GetChild(i).gameObject;
            _missileList.Add(tObj);

            if (i != (int)_missileType) tObj.SetActive(false);
            else tObj.SetActive(true);
        }

        switch(_missileType)
        {
            case MissileType.Arrow:
                _speed = 5f;
                _timeForLim = 10f;
                //_homing = false;
                _range = 0;
                _yPos = 2f;
                _yPosSave = _yPos;
                break;

            case MissileType.FireBall:
                _speed = 3f;
                _timeForLim = 10f;
                //_homing = true;
                _range = 2f;

                _yPos = -1f;
                _yPosSave = _yPos;
                break;
        }
    }


    public void SetMissile(MissileType type, SA_Unit owner, SA_Unit target)
    {
        transform.position = owner.transform.position + new Vector3(0, 0.25f, 0);
        _startPos = transform.position;

        _missileType = type;
        _owner = owner;
        _target = target;

        tTag = _target.tag;

        _endPos = (Vector2)_target.transform.position + new Vector2(0, 0.25f);
        _timer = 0;

        SoonsoonData.Instance.SAMM._poolListUse.Add(this);
        SetInit();

        gameObject.SetActive(true);
    }

    public void DoMove()
    {
        if (_homing)
        {
            if (TargetCheck())
            {
                _endPos = (Vector2)_target.transform.position + new Vector2(0, 0.25f);
            }
        }

        Vector2 tVec = _endPos - (Vector2)transform.position;

        float tDis = tVec.sqrMagnitude;
        if (tDis > 0.1f)
        {
            Vector2 tDirVec = (tVec).normalized;
            Vector3 tVVect;
            if (_yPos == -1f)
            {
                tVVect = (_speed * (Vector3)tDirVec);
            }
            else
            {
                _yPos -= _yPosSave * Time.deltaTime;
                tVVect = (_speed * (Vector3)tDirVec + new Vector3(0, _yPos, 0));
            }
            transform.position += tVVect * Time.deltaTime;
            transform.up = tVVect;

        }
        else
        {
            DoProcess();
        }
    }


    /*void DoProcess()
    {
        if(_range > 0)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 1f);
            if(hit.Length > 0)
            {
                foreach(var obj in hit)
                {
                    if(obj.CompareTag(tTag))
                    {
                        _owner.AttackDone(obj.GetComponent<SA_Unit>());
                    }
                }
            }
        }
        else
        {
            if (TargetCheck()) _owner.AttackDone();
        }
    }

}*/
