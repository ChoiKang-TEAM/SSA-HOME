using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using System;

public static class Extension
{
    // using System.Collections.Generic;
    public static IEnumerable<int> FindEveryIndex<T>(this IEnumerable<T> items,
                                                     Predicate<T> predicate)
    {
        int index = 0; bool found = false;
        foreach (var item in items)
        {
            if (predicate(item))
            {
                found = true; yield return index;
            };
            index++;
        }
        if (!found) yield return -1;
    }
}

public class UnitController : MonoBehaviour
{
    public GameObject[] synergy;
    public GameObject r_PlayerController;
    public GameObject[] Cost01_1;
    public GameObject[] Cost01_2;
    public GameObject[] Cost01_3;
    public GameObject[] Cost02_1, Cost02_2, Cost02_3;
    public GameObject[] Cost03_1, Cost03_2, Cost03_3;
    public GameObject[] Cost04_1, Cost04_2, Cost04_3;
    public GameObject[] Cost05_1, Cost05_2, Cost05_3;
    public Sprite[] C1, C2, C3, C4, C5;
    public string[] C1_name, C2_name, C3_name, C4_name, C5_name;
    public Text text1, text2, text3, text4, text5;
    public GameObject parentObject;

    public GameObject battleFieldObj;

    int star_check;
    bool isFull;
    List<string> SaveUnits = new List<string>();
    NoticeUI _notice;
    public void Buy_Unit()
    {
        int Lastindex, count;
        string target;
        
        if (parentObject.transform.childCount == 8)
        {
            isFull = true;
        }

        if(isFull)
        {
            _notice.SUB("대기열이 꽉 찼습니다.");
        }
        else
        {
            isFull = false;
            
            // 1 COST
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost1_000")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 1)
                {
                    GameObject Cost01_000 = Instantiate(Cost01_1[0], transform.position, Quaternion.identity);
                    Cost01_000.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 1);
                    PlayerPrefs.SetInt("cost_index", 0);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");
                
             

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost1_001")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 1)
                {
                    GameObject Cost01_001 = Instantiate(Cost01_1[1], transform.position, Quaternion.identity);
                    Cost01_001.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 1);
                    PlayerPrefs.SetInt("cost_index", 1);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");


            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost1_002")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 1)
                {
                    GameObject Cost01_002 = Instantiate(Cost01_1[2], transform.position, Quaternion.identity);
                    Cost01_002.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 1);
                    PlayerPrefs.SetInt("cost_index", 2);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost1_003")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 1)
                {
                    GameObject Cost01_003 = Instantiate(Cost01_1[3], transform.position, Quaternion.identity);
                    Cost01_003.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 1);
                    PlayerPrefs.SetInt("cost_index", 3);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost1_004")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 1)
                {
                    GameObject Cost01_004 = Instantiate(Cost01_1[4], transform.position, Quaternion.identity);
                    Cost01_004.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 1);
                    PlayerPrefs.SetInt("cost_index", 4);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost1_005")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 1)
                {
                    GameObject Cost01_005 = Instantiate(Cost01_1[5], transform.position, Quaternion.identity);
                    Cost01_005.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 1);
                    PlayerPrefs.SetInt("cost_index", 5);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost1_006")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 1)
                {
                    GameObject Cost01_006 = Instantiate(Cost01_1[6], transform.position, Quaternion.identity);
                    Cost01_006.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 1);
                    PlayerPrefs.SetInt("cost_index", 6);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost1_007")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 1)
                {
                    GameObject Cost01_007 = Instantiate(Cost01_1[7], transform.position, Quaternion.identity);
                    Cost01_007.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 1);
                    PlayerPrefs.SetInt("cost_index", 7);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }

            // 2 COST
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost2_000")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 2)
                {
                    GameObject Cost02_000 = Instantiate(Cost02_1[0], transform.position, Quaternion.identity);
                    Cost02_000.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 2);
                    PlayerPrefs.SetInt("cost_index", 0);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost2_001")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 2)
                {
                    GameObject Cost02_001 = Instantiate(Cost02_1[1], transform.position, Quaternion.identity);
                    Cost02_001.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 2);
                    PlayerPrefs.SetInt("cost_index", 1);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost2_002")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 2)
                {
                    GameObject Cost02_002 = Instantiate(Cost02_1[2], transform.position, Quaternion.identity);
                    Cost02_002.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 2);
                    PlayerPrefs.SetInt("cost_index", 2);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost2_003")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 2)
                {
                    GameObject Cost02_003 = Instantiate(Cost02_1[3], transform.position, Quaternion.identity);
                    Cost02_003.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 2);
                    PlayerPrefs.SetInt("cost_index", 3);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");
            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost2_004")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 2)
                {
                    GameObject Cost02_004 = Instantiate(Cost02_1[4], transform.position, Quaternion.identity);
                    Cost02_004.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 2);
                    PlayerPrefs.SetInt("cost_index", 4);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost2_005")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 2)
                {
                    GameObject Cost02_005 = Instantiate(Cost02_1[5], transform.position, Quaternion.identity);
                    Cost02_005.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 2);
                    PlayerPrefs.SetInt("cost_index", 5);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost2_006")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 2)
                {
                    GameObject Cost02_006 = Instantiate(Cost02_1[6], transform.position, Quaternion.identity);
                    Cost02_006.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 2);
                    PlayerPrefs.SetInt("cost_index", 6);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost2_007")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 2)
                {
                    GameObject Cost02_007 = Instantiate(Cost02_1[7], transform.position, Quaternion.identity);
                    Cost02_007.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 2);
                    PlayerPrefs.SetInt("cost_index", 7);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }

            // COST 3
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost3_000")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 3)
                {
                    GameObject Cost03_000 = Instantiate(Cost03_1[0], transform.position, Quaternion.identity);
                    Cost03_000.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 3);
                    PlayerPrefs.SetInt("cost_index", 0);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

                }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost3_001")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 3)
                {
                    GameObject Cost03_001 = Instantiate(Cost03_1[1], transform.position, Quaternion.identity);
                    Cost03_001.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 3);
                    PlayerPrefs.SetInt("cost_index", 1);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost3_002")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 3)
                {
                    GameObject Cost03_002 = Instantiate(Cost03_1[2], transform.position, Quaternion.identity);
                    Cost03_002.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 3);
                    PlayerPrefs.SetInt("cost_index", 2);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost3_003")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 3)
                {
                    GameObject Cost03_003 = Instantiate(Cost03_1[3], transform.position, Quaternion.identity);
                    Cost03_003.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 3);
                    PlayerPrefs.SetInt("cost_index", 3);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");
            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost3_004")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 3)
                {
                    GameObject Cost03_004 = Instantiate(Cost03_1[4], transform.position, Quaternion.identity);
                    Cost03_004.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 3);
                    PlayerPrefs.SetInt("cost_index", 4);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost3_005")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 3)
                {
                    GameObject Cost03_005 = Instantiate(Cost03_1[5], transform.position, Quaternion.identity);
                    Cost03_005.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 3);
                    PlayerPrefs.SetInt("cost_index", 5);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }

            // COST 4
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost4_000")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 4)
                {
                    GameObject Cost04_000 = Instantiate(Cost04_1[0], transform.position, Quaternion.identity);
                    Cost04_000.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 4);
                    PlayerPrefs.SetInt("cost_index", 0);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost4_001")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 4)
                {
                    GameObject Cost04_001 = Instantiate(Cost04_1[1], transform.position, Quaternion.identity);
                    Cost04_001.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 4);
                    PlayerPrefs.SetInt("cost_index", 1);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost4_002")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 4)
                {
                    GameObject Cost04_002 = Instantiate(Cost04_1[2], transform.position, Quaternion.identity);
                    Cost04_002.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 4);
                    PlayerPrefs.SetInt("cost_index", 2);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost4_003")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 4)
                {
                    GameObject Cost04_003 = Instantiate(Cost04_1[3], transform.position, Quaternion.identity);
                    Cost04_003.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 4);
                    PlayerPrefs.SetInt("cost_index", 3);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");
            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost4_004")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 4)
                {
                    GameObject Cost04_004 = Instantiate(Cost04_1[4], transform.position, Quaternion.identity);
                    Cost04_004.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 4);
                    PlayerPrefs.SetInt("cost_index", 4);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost4_005")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 4)
                {
                    GameObject Cost04_005 = Instantiate(Cost04_1[5], transform.position, Quaternion.identity);
                    Cost04_005.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 4);
                    PlayerPrefs.SetInt("cost_index", 5);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }

            // COST 05
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost5_000")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 5)
                {
                    GameObject Cost05_000 = Instantiate(Cost05_1[0], transform.position, Quaternion.identity);
                    Cost05_000.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 5);
                    PlayerPrefs.SetInt("cost_index", 0);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost5_001")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 5)
                {
                    GameObject Cost05_001 = Instantiate(Cost05_1[1], transform.position, Quaternion.identity);
                    Cost05_001.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 5);
                    PlayerPrefs.SetInt("cost_index", 1);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost5_002")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 5)
                {
                    GameObject Cost05_002 = Instantiate(Cost05_1[2], transform.position, Quaternion.identity);
                    Cost05_002.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 5);
                    PlayerPrefs.SetInt("cost_index", 2);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");

            }
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name == "Cost5_003")
            {
                if (r_PlayerController.GetComponent<R_PlayerController>().coin >= 5)
                {
                    GameObject Cost05_003 = Instantiate(Cost05_1[3], transform.position, Quaternion.identity);
                    Cost05_003.transform.SetParent(parentObject.transform, false);
                    PlayerPrefs.SetInt("cost", 5);
                    PlayerPrefs.SetInt("cost_index", 3);
                }
                else
                    _notice.SUB("코인이 부족합니다.!");
            }
            r_PlayerController.GetComponent<R_PlayerController>().coin -= PlayerPrefs.GetInt("cost");
            Lastindex = parentObject.transform.childCount;

            if (Lastindex >= 1 && Lastindex <= 8)
            {
                SaveUnits.Add(parentObject.transform.GetChild(Lastindex - 1).name);
            }

            target = SaveUnits[SaveUnits.Count - 1];

            count = SaveUnits.Where(x => x.Equals(target)).Count();

            if (count >= 3)
            {
                star_check = 1;
                List<int> idx = SaveUnits.FindEveryIndex(x => x == target).ToList();
                target = UnitCombine(idx, target);
                count = SaveUnits.Where(x => x.Equals(target)).Count();

                if (count >= 3)
                {
                    star_check = 2;
                    idx = SaveUnits.FindEveryIndex(x => x == target).ToList();
                    target = UnitCombine(idx, target);
                }

            }
            EventSystem.current.currentSelectedGameObject.gameObject.SetActive(false);


        }

    }
    
    public string UnitCombine(List<int> idxArr, string pivotdt)
    {
        int a0 = idxArr[0];
        int a1 = idxArr[1] - 1;
        int a2 = idxArr[2] - 2;
        Destroy(parentObject.transform.GetChild(a0).gameObject);
        Destroy(parentObject.transform.GetChild(a1 + 1).gameObject);
        Destroy(parentObject.transform.GetChild(a2 + 2).gameObject);
        SaveUnits.RemoveAt(a0);
        SaveUnits.RemoveAt(a1);
        SaveUnits.RemoveAt(a2);
        GameObject targetObject;
        switch(PlayerPrefs.GetInt("cost"))
        {
            case 1:
                if (star_check == 1)
                {
                    targetObject = Instantiate(Cost01_2[PlayerPrefs.GetInt("cost_index")], transform.position, Quaternion.identity);
                    targetObject.transform.SetParent(parentObject.transform, false);
                    targetObject.transform.SetSiblingIndex(a0);
                    pivotdt = targetObject.name;
                    SaveUnits.Insert(a0, pivotdt);
                    return pivotdt;
                }
                if (star_check == 2)
                {
                    targetObject = Instantiate(Cost01_3[PlayerPrefs.GetInt("cost_index")], transform.position, Quaternion.identity);
                    targetObject.transform.SetParent(parentObject.transform, false);
                    targetObject.transform.SetSiblingIndex(a0);
                    pivotdt = targetObject.name;
                    SaveUnits.Insert(a0, pivotdt);
                    return pivotdt;
                }

                Debug.Log("1코의 이름 : " + pivotdt);
                break;
            case 2:
                if (star_check == 1)
                {
                    targetObject = Instantiate(Cost02_2[PlayerPrefs.GetInt("cost_index")], transform.position, Quaternion.identity);
                    targetObject.transform.SetParent(parentObject.transform, false);
                    targetObject.transform.SetSiblingIndex(a0);
                    pivotdt = targetObject.name;
                    SaveUnits.Insert(a0, pivotdt);
                    return pivotdt;
                }
                if (star_check == 2)
                {
                    targetObject = Instantiate(Cost02_3[PlayerPrefs.GetInt("cost_index")], transform.position, Quaternion.identity);
                    targetObject.transform.SetParent(parentObject.transform, false);
                    targetObject.transform.SetSiblingIndex(a0);
                    pivotdt = targetObject.name;
                    SaveUnits.Insert(a0, pivotdt);
                    return pivotdt;
                }
                break;
            case 3:
                if (star_check == 1)
                {
                    targetObject = Instantiate(Cost03_2[PlayerPrefs.GetInt("cost_index")], transform.position, Quaternion.identity);
                    targetObject.transform.SetParent(parentObject.transform, false);
                    targetObject.transform.SetSiblingIndex(a0);
                    pivotdt = targetObject.name;
                    SaveUnits.Insert(a0, pivotdt);
                    return pivotdt;
                }
                if (star_check == 2)
                {
                    targetObject = Instantiate(Cost03_3[PlayerPrefs.GetInt("cost_index")], transform.position, Quaternion.identity);
                    targetObject.transform.SetParent(parentObject.transform, false);
                    targetObject.transform.SetSiblingIndex(a0);
                    pivotdt = targetObject.name;
                    SaveUnits.Insert(a0, pivotdt);
                    return pivotdt;
                }
                break;
            case 4:
                if (star_check == 1)
                {
                    targetObject = Instantiate(Cost04_2[PlayerPrefs.GetInt("cost_index")], transform.position, Quaternion.identity);
                    targetObject.transform.SetParent(parentObject.transform, false);
                    targetObject.transform.SetSiblingIndex(a0);
                    pivotdt = targetObject.name;
                    SaveUnits.Insert(a0, pivotdt);
                    return pivotdt;
                }
                if (star_check == 2)
                {
                    targetObject = Instantiate(Cost04_3[PlayerPrefs.GetInt("cost_index")], transform.position, Quaternion.identity);
                    targetObject.transform.SetParent(parentObject.transform, false);
                    targetObject.transform.SetSiblingIndex(a0);
                    pivotdt = targetObject.name;
                    SaveUnits.Insert(a0, pivotdt);
                    return pivotdt;
                }
                break;
            case 5:
                if (star_check == 1)
                {
                    targetObject = Instantiate(Cost05_2[PlayerPrefs.GetInt("cost_index")], transform.position, Quaternion.identity);
                    targetObject.transform.SetParent(parentObject.transform, false);
                    targetObject.transform.SetSiblingIndex(a0);
                    pivotdt = targetObject.name;
                    SaveUnits.Insert(a0, pivotdt);
                    return pivotdt;
                }
                if (star_check == 2)
                {
                    targetObject = Instantiate(Cost05_3[PlayerPrefs.GetInt("cost_index")], transform.position, Quaternion.identity);
                    targetObject.transform.SetParent(parentObject.transform, false);
                    targetObject.transform.SetSiblingIndex(a0);
                    pivotdt = targetObject.name;
                    SaveUnits.Insert(a0, pivotdt);
                    return pivotdt;
                }
                break;

        }
        return null;
        // GameObject Cost01_000_2 = Instantiate(Cost01_2[0], transform.position, Quaternion.identity);
        //targetObject.transform.SetParent(parentObject.transform, false);
        //targetObject.transform.SetSiblingIndex(a0);
        //pivotdt = targetObject.name;
        //SaveUnits.Insert(a0, pivotdt);
        //return pivotdt;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        synergy[0].SetActive(true);
    }
    private void Awake()
    {
        _notice = FindObjectOfType<NoticeUI>();
        isFull = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
