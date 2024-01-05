using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField] GameObject r_PlayerController;
    [SerializeField] Text total_gold; // ���� ���
    [SerializeField] Text Win_gold; // �¸� ����
    [SerializeField] Text Benefit_gold; // ����
    [SerializeField] Text Stage_gold; // �������� ���ʽ�

    public void SetToolTip()
    {
        //���� ����

        Win_gold.text = "+ " + 5.ToString();
        Stage_gold.text = "+ " + r_PlayerController.GetComponent<R_PlayerController>().StageBonus.ToString();
        if (r_PlayerController.GetComponent<R_PlayerController>().coin / 10 >= 5)
        {
            Benefit_gold.text = "+ " + 5.ToString();
        }
        else
        {
            Benefit_gold.text = "+ " + (r_PlayerController.GetComponent<R_PlayerController>().coin / 10).ToString();
        }
        total_gold.text = "+ " + (int.Parse(Regex.Replace(Win_gold.text, @"\D", "")) + int.Parse(Regex.Replace(Stage_gold.text, @"\D", "")) + int.Parse(Regex.Replace(Benefit_gold.text, @"\D", ""))).ToString();

        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Input.mousePosition;
    }
}
