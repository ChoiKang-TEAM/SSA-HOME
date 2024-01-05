using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ToolTip toolTip;
    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.GetComponent<ToolTip>().SetToolTip();
        toolTip.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
