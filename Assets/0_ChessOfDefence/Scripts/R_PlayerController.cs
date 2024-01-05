using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_PlayerController : MonoBehaviour
{
    public Text text;
    public Button EXUP_Button;
    public int Level;
    public int MaxExp;
    public int NowExp;
    public int coin;
    public int StageBonus;
    public Text c1, c2, c3, c4, c5;
    public int[] L_P = new int[5] { 0, 0, 0, 0, 0 };
    // Start is called before the first frame update
    private void Awake()
    {
        coin = 1000;
    }
    void Start()
    {
        PlayerPrefs.SetInt("winlose", 3);
        StageBonus = 3;
        Level = 1;
        Player_Pers();
        MaxExp = 2;
        NowExp = 0;
        this.text.text = string.Format("Lv. {0}    {1}/{2}", this.Level, this.NowExp, this.MaxExp); // Lv. 1      0/4
    }
    public void Player_Pers()
    {
        switch (Level)
        {
            case 1:
                L_P = new int[] { 100, 0, 0, 0, 0 };
                c1.text = L_P[0].ToString() + "%";
                c2.text = L_P[1].ToString() + "%";
                c3.text = L_P[2].ToString() + "%";
                c4.text = L_P[3].ToString() + "%";
                c5.text = L_P[4].ToString() + "%";
                break;

            case 2:
                L_P = new int[] { 60, 40, 0, 0, 0 };
                c1.text = L_P[0].ToString() + "%";
                c2.text = L_P[1].ToString() + "%";
                c3.text = L_P[2].ToString() + "%";
                c4.text = L_P[3].ToString() + "%";
                c5.text = L_P[4].ToString() + "%";
                break;

            case 3:
                L_P = new int[] { 45, 50, 5, 0, 0 };
                c1.text = L_P[0].ToString() + "%";
                c2.text = L_P[1].ToString() + "%";
                c3.text = L_P[2].ToString() + "%";
                c4.text = L_P[3].ToString() + "%";
                c5.text = L_P[4].ToString() + "%";
                break;

            case 4:
                L_P = new int[] { 40, 49, 9, 2, 0 };
                c1.text = L_P[0].ToString() + "%";
                c2.text = L_P[1].ToString() + "%";
                c3.text = L_P[2].ToString() + "%";
                c4.text = L_P[3].ToString() + "%";
                c5.text = L_P[4].ToString() + "%";
                break;

            case 5:
                L_P = new int[] { 30, 50, 15, 5, 0 };
                c1.text = L_P[0].ToString() + "%";
                c2.text = L_P[1].ToString() + "%";
                c3.text = L_P[2].ToString() + "%";
                c4.text = L_P[3].ToString() + "%";
                c5.text = L_P[4].ToString() + "%";
                break;
            case 6:
                L_P = new int[] { 30, 30, 30, 10, 0 };
                c1.text = L_P[0].ToString() + "%";
                c2.text = L_P[1].ToString() + "%";
                c3.text = L_P[2].ToString() + "%";
                c4.text = L_P[3].ToString() + "%";
                c5.text = L_P[4].ToString() + "%";
                break;
            case 7:
                L_P = new int[] { 20, 24, 40, 15, 1 };
                c1.text = L_P[0].ToString() + "%";
                c2.text = L_P[1].ToString() + "%";
                c3.text = L_P[2].ToString() + "%";
                c4.text = L_P[3].ToString() + "%";
                c5.text = L_P[4].ToString() + "%";
                break;
            case 8:
                L_P = new int[] { 15, 15, 40, 25, 5 };
                c1.text = L_P[0].ToString() + "%";
                c2.text = L_P[1].ToString() + "%";
                c3.text = L_P[2].ToString() + "%";
                c4.text = L_P[3].ToString() + "%";
                c5.text = L_P[4].ToString() + "%";
                break;
            case 9:
                L_P = new int[] { 5, 10, 30, 40, 15 };
                c1.text = L_P[0].ToString() + "%";
                c2.text = L_P[1].ToString() + "%";
                c3.text = L_P[2].ToString() + "%";
                c4.text = L_P[3].ToString() + "%";
                c5.text = L_P[4].ToString() + "%";
                break;
            case 10:
                L_P = new int[] { 2, 3, 15, 40, 40 };
                c1.text = L_P[0].ToString() + "%";
                c2.text = L_P[1].ToString() + "%";
                c3.text = L_P[2].ToString() + "%";
                c4.text = L_P[3].ToString() + "%";
                c5.text = L_P[4].ToString() + "%";
                break;
        }
    }
    public void Stat()
    {
        if(NowExp >= MaxExp)
        {
            if (Level < 10)
            {
                Level++;
                NowExp -= MaxExp;
            }
            switch(Level)
            {
                case 1:
                    MaxExp = 2;
                    break;
                case 2:
                    MaxExp = 4;
                    break;
                case 3:
                    MaxExp = 8;
                    break;
                case 4:
                    MaxExp = 16;
                    break;
                case 5:
                    MaxExp = 24;
                    break;
                case 6:
                    MaxExp = 32;
                    break;
                case 7:
                    MaxExp = 48;
                    break;
                case 8:
                    MaxExp = 64;
                    break;
                case 9:
                    MaxExp = 80;
                    break;
                case 10:
                    NowExp = 0;
                    MaxExp = 0;
                    EXUP_Button.interactable = false;
                    break;

            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        Stat();
    }
}
