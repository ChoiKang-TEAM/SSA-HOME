using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public AudioClip AlertAudio;
    AudioSource audioSource;
    Slider slTimer;
    float fSliderBarTime = 25f;
    public Text text;
    public NextRound nextRound;
    // Start is called before the first frame update
    void Start()
    {
        slTimer = GetComponent<Slider>();
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
     
        if(PlayerPrefs.GetInt("winlose") == 0 || PlayerPrefs.GetInt("winlose") == 1)
        {
            return;
        }

        if (slTimer.value > 0.0f)
        {
            slTimer.value -= Time.deltaTime * 50;
            fSliderBarTime -= Time.deltaTime;
            text.text = Mathf.Round(fSliderBarTime).ToString();
        }
        else
        {
            nextRound.NextR();
            slTimer.value = 100f;
            text.text = "25";
            fSliderBarTime = 25;
        }
    }
}
