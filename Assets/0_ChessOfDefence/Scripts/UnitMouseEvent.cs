using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitMouseEvent : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    NoticeUI _notice;
    private void Start()
    {
        
        
        
    }
    private void Awake()
    {
        _notice = FindObjectOfType<NoticeUI>();
    }

    [System.Obsolete]
    public void ClickBtn()
    {
        Debug.Log(transform.name);
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        switch (transform.parent.name)
        {
            case "StayField":
                string targetName = transform.name.Replace("(Clone)", "");
                GameObject btnObj = GameObject.Find("Heros").transform.FindChild(targetName).gameObject;
                if (btnObj.activeInHierarchy)
                {
                    _notice.SUB("�̹� ��ϵǾ� �ֽ��ϴ�!");
                }
                else
                {
                    btnObj.SetActive(true);
                    gameObject.SetActive(false);
                }
                break;
            case "Heros":
                string ttargetName = transform.name + "(Clone)";
                GameObject btnObj2 = GameObject.Find("StayField").transform.FindChild(ttargetName).gameObject;
                btnObj2.SetActive(true);
                gameObject.SetActive(false);
                break;
        }
        
    }
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 1.0f;
        gameObject.transform.position = mousepos;
        
    }
    private void OnMouseDrag()
    {
        
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 1.0f;
        gameObject.transform.position = mousepos;
        


    }
    private void OnMouseUp()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        Debug.Log("�巡�� ����");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�� ��");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BattleField")
        {
            Debug.Log("����� �����ϴ� ���Դϴ�.");
           
        }

        if (other.gameObject.tag == "StayField")
        {
            Debug.Log("����� ����ϴ� ���Դϴ�.");
        }
    }

    
}
