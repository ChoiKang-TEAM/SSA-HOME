using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

public class ReRoll : MonoBehaviour
{
    public GameObject nextRound;
    public Text leveltext;
    public GameObject r1, r2, r3, r4, r5;
    public Sprite ReRoll_Image;
    public GameObject r_PlayerController;
    public GameObject unitController;
    public Text cointext;
    NoticeUI _notice;
    public int[] Cost_Arr = new int[5];
    private int[,] unit_Index = new int[5, 2];

    private void Awake()
    {
        _notice = FindObjectOfType<NoticeUI>();
    }
    private int Cost_Return(int[] Chance_arr)
    {
        int sum = 0;
        int coin;
        float rand = Random.Range(0.0f , 1.0f); // 0.01 0.07 0.4
        for(int i = 0; i < Chance_arr.Length; i++)
        {
            sum += Chance_arr[i];
            if (rand <= (float)sum / 100)
            {
                coin = i;
                return coin + 1;
            }
        }
        return -1;
    }

    private int[,] Unit_Index(int[] Cost_arr)
    {
        int[,] unit_index = new int[Cost_arr.Length, 2];
        int cost;
        for (int i = 0; i < Cost_arr.Length; i++)
        {
            cost = Cost_arr[i];
            switch (cost)
            {
                case 1:
                    unit_index[i, 0] = cost;
                    unit_index[i, 1] = Random.Range(0, 8);
                    break;
                case 2:
                    unit_index[i, 0] = cost;
                    unit_index[i, 1] = Random.Range(0, 8);
                    break;
                case 3:
                    unit_index[i, 0] = cost;
                    unit_index[i, 1] = Random.Range(0, 6);
                    break;
                case 4:
                    unit_index[i, 0] = cost;
                    unit_index[i, 1] = Random.Range(0, 6);
                    break;
                case 5:
                    unit_index[i, 0] = cost;
                    unit_index[i, 1] = Random.Range(0, 4);
                    break;
            }
        }
        return unit_index;
    }

    private Sprite Unit_Sprite(int unit_cost, int unit_idx)
    {
        switch (unit_cost)
        {
            case 1:
                return unitController.GetComponent<UnitController>().C1[unit_idx];
            case 2:
                return unitController.GetComponent<UnitController>().C2[unit_idx];
            case 3:
                return unitController.GetComponent<UnitController>().C3[unit_idx];
            case 4:
                return unitController.GetComponent<UnitController>().C4[unit_idx];
            case 5:
                return unitController.GetComponent<UnitController>().C5[unit_idx];

        }
        return null;
    }
    private string[] Search_Cost_Object(int unit_cost)
    {
        switch (unit_cost)
        {
            case 1:
                return unitController.GetComponent<UnitController>().C1_name;
            case 2:
                return unitController.GetComponent<UnitController>().C2_name;
            case 3:
                return unitController.GetComponent<UnitController>().C3_name;
            case 4:
                return unitController.GetComponent<UnitController>().C4_name;
            case 5:
                return unitController.GetComponent<UnitController>().C5_name;
        }
        return null;
    }
    private Color name_color(int unit_cost)
    {
        
        switch (unit_cost)
        {
            case 1:
                
                return new Color(56f / 255f, 56f / 255f, 56f / 255f);
            case 2:
                return new Color(41f / 255f, 233f / 255f, 170f / 255f);
            case 3:
                return new Color(39f / 255f, 39f / 255f, 248f / 255f);
            case 4:
                return new Color(233f / 255f, 41f / 255f, 198f / 255f);
            case 5:
                return new Color(255f / 255f, 171f / 255f, 0f / 255f);
        }
        return new Color(255f, 255f, 255f);

    }
    
    public void Re_Roll()
    {
        r1.gameObject.SetActive(true);
        r2.gameObject.SetActive(true);
        r3.gameObject.SetActive(true);
        r4.gameObject.SetActive(true);
        r5.gameObject.SetActive(true);

        if (nextRound.GetComponent<NextRound>().isTrue == true)
        {
            Debug.Log("판 넘어가서 리롤이요");
            //r_PlayerController.GetComponent<R_PlayerController>().Player_Pers();
            //Debug.Log(Cost_Return(r_PlayerController.GetComponent<R_PlayerController>().L_P));
        }
        if (nextRound.GetComponent<NextRound>().isTrue == false)
        {
            Debug.Log("돈 주고 리롤이요");
            if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 2)
            {
                r_PlayerController.GetComponent<R_PlayerController>().coin -= 2;
                r_PlayerController.GetComponent<R_PlayerController>().Player_Pers();
                for (int i = 0; i < 5; i++)
                    Cost_Arr[i] = Cost_Return(r_PlayerController.GetComponent<R_PlayerController>().L_P);

                unit_Index = Unit_Index(Cost_Arr);

                r1.GetComponent<Button>().image.sprite = Unit_Sprite(unit_Index[0, 0], unit_Index[0, 1]);
                r1.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = unit_Index[0, 0].ToString();
                r1.gameObject.transform.GetChild(0).GetComponent<Image>().color = name_color(unit_Index[0, 0]);
                r1.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Search_Cost_Object(unit_Index[0, 0])[unit_Index[0, 1]];

                r2.GetComponent<Button>().image.sprite = Unit_Sprite(unit_Index[1, 0], unit_Index[1, 1]);
                r2.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = unit_Index[1, 0].ToString();
                r2.gameObject.transform.GetChild(0).GetComponent<Image>().color = name_color(unit_Index[1, 0]);
                r2.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Search_Cost_Object(unit_Index[1, 0])[unit_Index[1, 1]];

                r3.GetComponent<Button>().image.sprite = Unit_Sprite(unit_Index[2, 0], unit_Index[2, 1]);
                r3.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = unit_Index[2, 0].ToString();
                r3.gameObject.transform.GetChild(0).GetComponent<Image>().color = name_color(unit_Index[2, 0]);
                r3.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Search_Cost_Object(unit_Index[2, 0])[unit_Index[2, 1]];

                r4.GetComponent<Button>().image.sprite = Unit_Sprite(unit_Index[3, 0], unit_Index[3, 1]);
                r4.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = unit_Index[3, 0].ToString();
                r4.gameObject.transform.GetChild(0).GetComponent<Image>().color = name_color(unit_Index[3, 0]);
                r4.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Search_Cost_Object(unit_Index[3, 0])[unit_Index[3, 1]];


                r5.GetComponent<Button>().image.sprite = Unit_Sprite(unit_Index[4, 0], unit_Index[4, 1]);
                r5.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = unit_Index[4, 0].ToString();
                r5.gameObject.transform.GetChild(0).GetComponent<Image>().color = name_color(unit_Index[4, 0]);
                r5.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Search_Cost_Object(unit_Index[4, 0])[unit_Index[4, 1]];
            }
            else
            {
                _notice.SUB("코인이 부족합니다!");
            }
        }



        cointext.text = r_PlayerController.GetComponent<R_PlayerController>().coin.ToString();
        this.leveltext.text = string.Format("Lv. {0}    {1}/{2}", r_PlayerController.GetComponent<R_PlayerController>().Level, r_PlayerController.GetComponent<R_PlayerController>().NowExp, r_PlayerController.GetComponent<R_PlayerController>().MaxExp);
        nextRound.GetComponent<NextRound>().isTrue = false;


        
        
    }
    public void ExpUP()
    {
        r_PlayerController.GetComponent<R_PlayerController>().NowExp += 4;
        if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 4)
        {
            r_PlayerController.GetComponent<R_PlayerController>().coin -= 4;
            r_PlayerController.GetComponent<R_PlayerController>().Stat();
            r_PlayerController.GetComponent<R_PlayerController>().Player_Pers();
            cointext.text = r_PlayerController.GetComponent<R_PlayerController>().coin.ToString();
            this.leveltext.text = string.Format("Lv. {0}    {1}/{2}", r_PlayerController.GetComponent<R_PlayerController>().Level, r_PlayerController.GetComponent<R_PlayerController>().NowExp, r_PlayerController.GetComponent<R_PlayerController>().MaxExp);
        }
        else
            _notice.SUB("코인이 부족합니다!");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(r_PlayerController.GetComponent<R_PlayerController>().coin);
        cointext.text = r_PlayerController.GetComponent<R_PlayerController>().coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
