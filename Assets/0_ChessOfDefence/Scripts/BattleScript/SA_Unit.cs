using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SA_Unit : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject[] WinLose;
    public bool _debug;
    public SPUM_Prefabs _spumPref;
    private new Rigidbody2D rigidbody;
    private GameObject DamageText;
    public enum UnitState
    {
        idle,
        run,
        attack,
        stun,
        death,
        skill
    }

    private GameObject HealthBar;
    public GameObject BackgroundHealthBar;
    public GameObject ManaBar;
    public GameObject BackgroundManaBar;
    public UnitState _unitState = UnitState.idle;

    public SA_Unit _target;

    public float _unitHP;
    public float _unitMs;
    public float _unitFR;
    public float _unitAT;
    public float _unitAS;
    public float _unitAR;
    public float _attackTimer;
    public Vector2 _dirVec;
    public Vector2 _tempDis;

    public float _findTimer;
    // Start is called before the first frame update
    void Start()
    {
        DamageText = GameObject.Find("Play");
        DamageText = DamageText.transform.GetChild(0).gameObject;
        HealthBar = _spumPref.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject;
        
        HealthBar.GetComponent<Slider>().maxValue = _unitHP;
        HealthBar.GetComponent<Slider>().value = _unitHP;
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody.velocity = Vector3.zero;
        //rigidbody.angularVelocity = 0.0f;
        CheckState();
    }

    void CheckState()
    {
        switch (_unitState)
        {
            case UnitState.idle:
                FindTarget();
                break;

            case UnitState.run:
                FindTarget();
                DoMove();
                break;

            case UnitState.attack:
                CheckAttack();
                break;

            case UnitState.skill:
                break;

            case UnitState.stun:
                break;

            case UnitState.death:
                break;
        }
    }
    void SetState(UnitState state)
    {
        _unitState = state;
        switch (_unitState)
        {
            case UnitState.idle:
                _spumPref.PlayAnimation("0_idle");
                break;

            case UnitState.run:
                _spumPref.PlayAnimation("1_Run");
                break;

            case UnitState.attack:
                _attackTimer += Time.deltaTime;
                if (_attackTimer > _unitAS)
                {
                    DoAttack();
                    _attackTimer = 0;
                }
                //_spumPref.PlayAnimation("0_idle");
                break;

            case UnitState.skill:
                _spumPref.PlayAnimation("5_Skill_Normal");
                break;

            case UnitState.stun:
                _spumPref.PlayAnimation("3_Debuff_Stun");
                break;

            case UnitState.death:
                _spumPref.PlayAnimation("4_Death");
                break;
        }
    }
    void FindTarget()
    {
        _findTimer += Time.deltaTime;
        if (_findTimer > SoonsoonData.Instance.SAM._findTimer)
        {
            _target = SoonsoonData.Instance.SAM.GetTarget(this);
            if (_target != null) SetState(UnitState.run);
            else SetState(UnitState.idle);
            _findTimer = 0;
        }
    }

    // 길찾기 알고리즘 오류 -> 수정 필요
    /*
    void FindWay()
    {
        // CheckDistance();
        _moveList.Clear();
        Vector2 tPos = transform.position;
        Debug.Log("길찾기 tPos" + tPos);

        float tmpValue = 0;
        bool chk = true;

        for (var j = 0; j < 10; j++)
        {
            bool chk2 = true;
            for (var i = 0; i < 6; i++)
            {
                _tempDis = (Vector2)_target.transform.position - tPos;
                Debug.Log("길찾기의 템프 dis " + _tempDis);
                Vector2 tDirVec = _tempDis.normalized;
                if (chk && chk2)
                {
                    tmpValue = i * 60f;
                    Vector3 ttDirVec = (Quaternion.AngleAxis(tmpValue, Vector3.forward) * tDirVec);
                    RaycastHit2D hit = Physics2D.CircleCast(tPos + new Vector2(0, 0.5f), 0.25f, ttDirVec, 1f);

                    if (hit.collider == null)
                    {
                        tDirVec = (Vector2)ttDirVec;
                        tPos += (Vector2)ttDirVec;
                        _moveList.Add(tPos);
                        chk2 = false;
                    }
                    else if (hit.collider.tag == _target.tag)
                    {
                        _target = hit.collider.GetComponent<SA_Unit>();
                        tDirVec = (Vector2)ttDirVec;
                        tPos += (Vector2)ttDirVec;
                        _moveList.Add(tPos);
                        chk2 = false;
                    }
                }
            }
        }
        if(_moveList.Count > 0)
        {
            SetState(UnitState.run);
        }
    
    }
    */
    void DoMove()
    {
        if (!CheckTarget()) return;
        CheckDistance();

        _dirVec = _tempDis.normalized;
        SetDirection();
        transform.position += (Vector3)_dirVec * _unitMs * Time.deltaTime;
    }

    bool CheckDistance()
    {
        _tempDis = (Vector2)(_target.transform.localPosition - transform.localPosition);
        float tDis = _tempDis.sqrMagnitude;
        if (tDis <= _unitAR * _unitAR)
        {
            SetState(UnitState.attack);
            return true;
        }
        else
        {
            if (!CheckTarget()) SetState(UnitState.idle);
            else SetState(UnitState.run);
            return false;
        }
    }

    void CheckAttack()
    {

        if (!CheckTarget()) return;
        if (!CheckDistance()) return;

        _attackTimer += Time.deltaTime;
        if (_attackTimer > _unitAS)
        {
            DoAttack();
            _attackTimer = 0;
        }
    }
    private void Awake()
    {
        audioSource = _spumPref.GetComponent<AudioSource>();
    }
    void DoAttack()
    {
        _spumPref.PlayAnimation("2_Attack_Normal");
        audioSource.Play();
        _target.GetComponent<SA_Unit>().GetDamage(_unitAT);


    }

    void SetDirection()
    {
        if (_dirVec.x >= 0)
        {
            _spumPref._anim.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            _spumPref._anim.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    bool CheckTarget()
    {
        bool value = true;
        if (_target == null) value = false;
        if (_target._unitState == UnitState.death) value = false;
        if (!_target.gameObject.activeInHierarchy) value = false;

        if (!value)
        {
            SetState(UnitState.idle);
        }
        return value;
    }


    /*
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(transform.tag))
        {
            
            int rd = Random.Range(0, 5);
            switch (rd)
            {
                case 1:
                    transform.position += ((Vector3)_dirVec + Vector3.right * 3) * _unitMs * Time.deltaTime;
                    break;
                case 2:
                    transform.position += ((Vector3)_dirVec + Vector3.left * 3) * _unitMs * Time.deltaTime;
                    break;
                case 3:
                    transform.position += ((Vector3)_dirVec + Vector3.up * 3) * _unitMs * Time.deltaTime;
                    break;
                case 4:
                    transform.position += ((Vector3)_dirVec + Vector3.down * 3) * _unitMs * Time.deltaTime;
                    break;

            }

        }
        else if (coll.gameObject.CompareTag(_target.tag))
        {
            Debug.Log("적군이랑 접촉");
        }

    }
    */

    public void GetDamage(float damage)
    {

        GameObject dmgText = Instantiate(DamageText, transform.position + Vector3.up * 0.9f, Quaternion.identity);
        dmgText.SetActive(true);
        int cri = Random.Range(0, 101);
        if (cri == 99 || cri == 100)
        {
            damage = damage * 1.5f;
            dmgText.transform.GetChild(0).gameObject.GetComponent<Text>().text = damage.ToString() + "!!";
            dmgText.transform.localScale = new Vector3(1.05f, 1.05f, 1);
        }
        else
        {
            dmgText.transform.GetChild(0).gameObject.GetComponent<Text>().text = damage.ToString();
        }
        _unitHP -= damage;
        HealthBar.GetComponent<Slider>().value = _unitHP;
        
        // HealthBar.GetComponent<Image>().fillAmount = Health / _unitHP;


        if (HealthBar.GetComponent<Slider>().value <= 0 && _unitState != UnitState.death)
        {
            HealthBar.GetComponent<Slider>().value = 0;
            _spumPref.GetComponent<SA_Unit>().SetDeath();
        }
       
        Destroy(dmgText, 0.3f);
    }

    public void SetDeath()
    {
        Destroy(HealthBar);
        //Destroy(BackgroundHealthBar);
        //Destroy(ManaBar);
        //Destroy(BackgroundManaBar);
        if (_spumPref.tag == "P2")
        {
            if (gameObject.name == "Unit010")
            {
                WinLose[0].SetActive(true);
                PlayerPrefs.SetInt("winlose", 0);
            }
            gameObject.SetActive(false);
        }
        else
        {
            if(gameObject.name == "Hero1")
            {
                WinLose[1].SetActive(true);
                PlayerPrefs.SetInt("winlose", 1);
            }
            SetState(UnitState.death);
        }

    }

}