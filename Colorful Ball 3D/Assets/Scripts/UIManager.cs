using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image whiteEffectImage;
    private int effectControl;
    public Animator layoutAnimator;
    public bool settingsButtonSituation = false;

    //Butonlar
    public GameObject settingsOpen;
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject vibrationOn;
    public GameObject vibrationOff;
    public GameObject iap;
    public GameObject information;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if(PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
    }

    //Buton Functions

    public void SettingsOpen()
    {
        if (settingsButtonSituation == false)
        {
            settingsButtonSituation = true;
            layoutAnimator.SetTrigger("Slide_in");

        }

        else if (settingsButtonSituation == true)
        {
            settingsButtonSituation = false;
            layoutAnimator.SetTrigger("Slide_out");
        }

        if (PlayerPrefs.GetInt("Sound") == 1) //If Sound is on
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
            AudioListener.volume = 1;
        }

        else if (PlayerPrefs.GetInt("Sound") == 2) //If sound is off
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
            AudioListener.volume = 0;
        }


        if (PlayerPrefs.GetInt("Vibration") == 1) // If vibration is on
        {
            vibrationOn.SetActive(true);
            vibrationOff.SetActive(false);
        }

        else if (PlayerPrefs.GetInt("Vibration") == 2) // If vibration is off
        {
            vibrationOn.SetActive(false);
            vibrationOff.SetActive(true);
        }
    }

    public void SoundOn()
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }

    public void SoundOff()
    {
        soundOff.SetActive(false);
        soundOn.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void VibrationOn()
    {
        vibrationOn.SetActive(false);
        vibrationOff.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }

    public void VibrationOff()
    {
        vibrationOff.SetActive(false);
        vibrationOn.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 1);
    }

    public IEnumerator WhiteEffect()
    {
        whiteEffectImage.gameObject.SetActive(true);
        while (effectControl == 0)
        {
            yield return new WaitForSeconds(0.0001f);
            whiteEffectImage.color += new Color(0, 0, 0, 0.1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r,
                                                    whiteEffectImage.color.g,
                                                    whiteEffectImage.color.b,1))
            {
                effectControl = 1;
            }
        }

        while (effectControl == 1)
        {
            yield return new WaitForSeconds(0.0001f);
            whiteEffectImage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r,
                                                    whiteEffectImage.color.g,
                                                    whiteEffectImage.color.b, 0))
            {
                effectControl = 2;
            }
        }

        if (effectControl == 2)
        {
            Debug.Log("White Effect Tamamlandı");
        }
    }

}
