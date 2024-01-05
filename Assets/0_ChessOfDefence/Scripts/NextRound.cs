using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextRound : MonoBehaviour
{
    public GameObject[] wave1;
    public GameObject[] wave2;
    public GameObject[] wave3;
    public GameObject[] wave4;
    public GameObject[] wave5;
    public GameObject[] wave6;
    public GameObject[] wave7;
    public GameObject[] wave8;
    public GameObject[] wave9;
    public GameObject[] wave10;
    public GameObject[] wave11;
    public GameObject[] wave12;
    public GameObject[] wave13;
    public GameObject[] wave14;
    public GameObject[] wave15;
    public GameObject[] bonusWave;
    public GameObject[] bonusWave2;

    public GameObject[] boss;
    public bool isTrue = false;
    public GameObject r_PlayerController;
    public ReRoll reRoll;
    public Text Round_text;
    int i = 0;
    public GameObject Round_Now;
    public Sprite Open_Gift;
    public GameObject Now_Cursor;
    public Image[] Benefit_Image;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject.Find(transform.GetChild(0).name).GetComponent<Image>().color = Color.yellow;
        for (int j = 0; j < wave1.Length; j++)
        {
            wave1[j].SetActive(true);
        }
    }
    private void Update()
    {
        int Benefit_coin = r_PlayerController.GetComponent<R_PlayerController>().coin / 10;
        if (Benefit_coin >= 5)
        {
            Benefit_coin = 5;
        }
        switch (Benefit_coin)
        {
            case 0:
                for (int i = Benefit_coin; i < 4; i++)
                    Benefit_Image[i].color = Color.gray;
                break;
            case 1:
                Benefit_Image[0].color = Color.yellow;
                for (int i = Benefit_coin; i < 4; i++)
                    Benefit_Image[i].color = Color.gray;
                break;
            case 2:
                Benefit_Image[1].color = Color.yellow;
                for (int i = Benefit_coin; i < 4; i++)
                    Benefit_Image[i].color = Color.gray;
                break;
            case 3:
                Benefit_Image[2].color = Color.yellow;
                for (int i = Benefit_coin; i < 4; i++)
                    Benefit_Image[i].color = Color.gray;
                break;
            case 4:
                Benefit_Image[3].color = Color.yellow;
                for (int i = Benefit_coin; i < 4; i++)
                    Benefit_Image[i].color = Color.gray;
                break;
            case 5:
                Benefit_Image[4].color = Color.yellow;
                break;
        }


    }
    void Benefit()
    {
        int Benefit_coin = r_PlayerController.GetComponent<R_PlayerController>().coin / 10;
        if(Benefit_coin >= 5)
        {
            Benefit_coin = 5;
        }
        switch (Benefit_coin)
        {
            case 0:
                for (int i = Benefit_coin; i < 4; i++)
                    Benefit_Image[i].color = Color.gray;
                break;
            case 1:
                r_PlayerController.GetComponent<R_PlayerController>().coin += Benefit_coin;
                Benefit_Image[0].color = Color.yellow;
                for (int i = Benefit_coin; i < 4; i++)
                    Benefit_Image[i].color = Color.gray;
                break;
            case 2:
                r_PlayerController.GetComponent<R_PlayerController>().coin += Benefit_coin;
                Benefit_Image[1].color = Color.yellow;
                for (int i = Benefit_coin; i < 4; i++)
                    Benefit_Image[i].color = Color.gray;
                break;
            case 3:
                r_PlayerController.GetComponent<R_PlayerController>().coin += Benefit_coin;
                Benefit_Image[2].color = Color.yellow;
                for (int i = Benefit_coin; i < 4; i++)
                    Benefit_Image[i].color = Color.gray;
                break;
            case 4:
                r_PlayerController.GetComponent<R_PlayerController>().coin += Benefit_coin;
                Benefit_Image[3].color = Color.yellow;
                for (int i = Benefit_coin; i < 4; i++)
                    Benefit_Image[i].color = Color.gray;
                break;
            case 5:
                r_PlayerController.GetComponent<R_PlayerController>().coin += Benefit_coin;
                Benefit_Image[4].color = Color.yellow;
                break;
        }
    }
    public void NextR()
    {
        if (i == 19) return;
        Benefit();
        r_PlayerController.GetComponent<R_PlayerController>().coin += 5;
        r_PlayerController.GetComponent<R_PlayerController>().coin += r_PlayerController.GetComponent<R_PlayerController>().StageBonus;
        if (r_PlayerController.GetComponent<R_PlayerController>().Level < 10)
        {
            r_PlayerController.GetComponent<R_PlayerController>().NowExp += 2;
        }
        r_PlayerController.GetComponent<R_PlayerController>().Stat();
        r_PlayerController.GetComponent<R_PlayerController>().Player_Pers();
        isTrue = true;
        // reRoll.Re_Roll();
        if (i == 0)
        {
            Now_Cursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(Now_Cursor.GetComponent<RectTransform>().anchoredPosition.x + 60f, Now_Cursor.GetComponent<RectTransform>().anchoredPosition.y);
        }
        if (i >= 9 && i <= 18)
        {
            Now_Cursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(Now_Cursor.GetComponent<RectTransform>().anchoredPosition.x + 60f, Now_Cursor.GetComponent<RectTransform>().anchoredPosition.y);
        }
        if (transform.GetChild(i).name == "GIFT")
        {
            GameObject.Find(transform.GetChild(i).name).GetComponent<Image>().sprite = Open_Gift;
        }
        GameObject.Find(transform.GetChild(i).name).GetComponent<Image>().color = Color.gray;
        

        i++;
        switch (i)
        {
            case 1:
                for (int j = 0; j < wave1.Length; j++)
                {
                    wave2[j].SetActive(true);
                }
                break;
            case 2:
                for (int j = 0; j < wave2.Length; j++)
                {
                    wave3[j].SetActive(true);
                }
                break;
            case 3:
                for(int j = 0; j < bonusWave2.Length; j++)
                {
                    bonusWave2[j].SetActive(true);
                    r_PlayerController.GetComponent<R_PlayerController>().coin += 20;
                }
                break;
            case 4:
                for (int j = 0; j < wave3.Length; j++)
                {
                    wave4[j].SetActive(true);
                }
                break;
            case 5:
                for (int j = 0; j < wave4.Length; j++)
                {
                    wave5[j].SetActive(true);
                }
                break;
            case 6:
                for (int j = 0; j < wave5.Length; j++)
                {
                    wave6[j].SetActive(true);
                }
                break;
            case 8:
                for (int j = 0; j < wave6.Length; j++)
                {
                    wave7[j].SetActive(true);
                }
                break;
            case 9:
                for (int j = 0; j < wave6.Length; j++)
                {
                    wave8[j].SetActive(true);
                }
                break;
            case 10:
                for (int j = 0; j < wave6.Length; j++)
                {
                    wave9[j].SetActive(true);
                }
                break;
            case 11:
                for (int j = 0; j < bonusWave.Length; j++)
                {
                    bonusWave[j].SetActive(true);
                    r_PlayerController.GetComponent<R_PlayerController>().coin += 20;
                }
                break;
            case 12:
                for (int j = 0; j < wave6.Length; j++)
                {
                    wave10[j].SetActive(true);
                }
                break;
            case 13:
                for (int j = 0; j < wave6.Length; j++)
                {
                    wave11[j].SetActive(true);
                }
                break;
            case 14:
                for (int j = 0; j < wave6.Length; j++)
                {
                    wave12[j].SetActive(true);
                }
                break;
            case 16:
                for (int j = 0; j < wave6.Length; j++)
                {
                    wave13[j].SetActive(true);
                }
                break;
            case 17:
                for (int j = 0; j < wave6.Length; j++)
                {
                    wave14[j].SetActive(true);
                }
                break;
            case 18:
                for (int j = 0; j < wave6.Length; j++)
                {
                    wave15[j].SetActive(true);
                }
                break;

        }
        GameObject.Find(transform.GetChild(i).name).GetComponent<Image>().color = Color.yellow;
        if (i >= 2 && i <= 9)
        {
            transform.GetChild(i - 2).gameObject.SetActive(false);
            transform.GetChild(i + 10).gameObject.SetActive(true);
            // gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x - 60f, gameObject.GetComponent<RectTransform>().anchoredPosition.y);
            // Debug.Log(gameObject.GetComponent<RectTransform>().anchoredPosition);
        }
        // 3, 7, 11, 15, 19
        if(i%4 == 3)
        {
            if (i == 7)
            {
                boss[0].SetActive(true);
            }
            else if(i == 15)
            {
                boss[1].SetActive(true);
            }
            else if(i == 19)
            {
                boss[2].SetActive(true);
            }
            Round_text.color = Color.red;
            if (transform.GetChild(i).name == "GIFT")
                Round_text.color = Color.yellow;
        }
        else
        {
            Round_text.color = Color.white;
        }
        Round_text.text = transform.GetChild(i).name;
    }
}
