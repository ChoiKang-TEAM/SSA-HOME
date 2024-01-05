using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void moveScene()
    {
        SceneManager.LoadScene(1);
    }
    public void moveScene2()
    {
        SceneManager.LoadScene(2);
    }
}
