using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    [Serializable]
    public class Sound
    {
        public string soundName;
        public AudioClip audioClip; 
    }

    public Sound[] bgmList, sfxList;
    public AudioSource bgmSource, sfxSource;
    public AudioMixer mixer;

    private bool isMasterOn = true;
    private bool isBGMOn = true;
    private bool isSFXOn = true;

    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        PlayerPrefs.SetFloat("Master", 1);
        PlayerPrefs.SetFloat("BGM", 1);
        PlayerPrefs.SetFloat("SFX", 1);

        PlayerPrefs.SetInt("isMasterOn",1);
        PlayerPrefs.SetInt("isBGMOn", 1);
        PlayerPrefs.SetInt("isSFXOn", 1);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopBGM();

        for (int i = 0; i < bgmList.Length; i++)
        {
            if (scene.name == bgmList[i].soundName)
                PlayBGM(bgmList[i].soundName);
            else
                continue;
        }
    }    

    public void PlayBGM(string name)
    {
        Sound bgmSound = Array.Find(bgmList, x => x.soundName == name);

        if (bgmSound == null)
        {
            Debug.LogWarning(bgmSound + "�� ã�� �� ����.");
        }
        else
        {
            if (bgmSource != null)
            {
                bgmSource.clip = bgmSound.audioClip;
                bgmSource.loop = true;
                bgmSource.Play();
                bgmSource.outputAudioMixerGroup = mixer.FindMatchingGroups("BGM")[0];
            }
            else
            {
                Debug.LogWarning("bgmSource�� null. AudioSource ������Ʈ�� Ȯ��.");
            }
        }
    }

    public void PlaySFX(string name)
    {
        Sound sfxSound = Array.Find(sfxList, x => x.soundName == name);

        if (sfxSound == null)
        {
            Debug.LogWarning(sfxSound + "�� ã�� �� ����");
        }
        else
        {
            sfxSource.PlayOneShot(sfxSound.audioClip); // ������ ����� Ŭ���� �� ���� ���
            sfxSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        }
    }

    public void StopBGM()
    {
        if(bgmSource != null)
            bgmSource.Stop();
    }
    
    public void StopSFX()
    {
        if (sfxSource != null)
            sfxSource.Stop();
    }

    // 0 : ��� ���� 1 : ��� ����
    public void ToggleMaster()
    {
        if (PlayerPrefs.GetInt("isMasterOn") == 1)
        {
            bgmSource.mute = true; 
            sfxSource.mute = true;

            PlayerPrefs.SetInt("isMasterOn", 0);
            PlayerPrefs.SetInt("isBGMOn", 0);
            PlayerPrefs.SetInt("isSFXOn", 0);
        }
        else
        {
            bgmSource.mute = false;
            sfxSource.mute = false;

            PlayerPrefs.SetInt("isMasterOn", 1);
            PlayerPrefs.SetInt("isBGMOn", 1);
            PlayerPrefs.SetInt("isSFXOn", 1);
        }
    }

    public void ToggleBGM()
    {
        if (PlayerPrefs.GetInt("isBGMOn") == 1)
        {
            bgmSource.mute = true; 
            PlayerPrefs.SetInt("isBGMOn", 0);

            if (PlayerPrefs.GetInt("isMasterOn") == 1 && PlayerPrefs.GetInt("isSFXOn") == 0)
            {
                PlayerPrefs.SetInt("isMasterOn", 0);
            }
        }
        else 
        {
            bgmSource.mute = false; 
            PlayerPrefs.SetInt("isBGMOn", 1);

            if (PlayerPrefs.GetInt("isMasterOn") == 0 && PlayerPrefs.GetInt("isSFXOn") == 0)
            {
                PlayerPrefs.SetInt("isMasterOn", 1);
            }
        }
        
    }

    public void ToggleSFX()
    {
        if (PlayerPrefs.GetInt("isSFXOn") == 1)
        {
            sfxSource.mute = true;
            PlayerPrefs.SetInt("isSFXOn", 0);

            if (PlayerPrefs.GetInt("isMasterOn") == 1 && PlayerPrefs.GetInt("isBGMOn") == 0)
            {
                PlayerPrefs.SetInt("isMasterOn", 0);
            }
        }
        else
        {
            sfxSource.mute = false;
            PlayerPrefs.SetInt("isSFXOn", 1);

            if (PlayerPrefs.GetInt("isMasterOn") == 0 && PlayerPrefs.GetInt("isBGMOn") == 0)
            {
                PlayerPrefs.SetInt("isMasterOn", 1);
            }
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        mixer.SetFloat("Master", Mathf.Log10(volume) * 20); // �ͽ� ������ log scale ���
        PlayerPrefs.SetFloat("Master", volume);
    }

    public void ChangeBGMVolume(float volume)
    {
        mixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("BGM", volume);
    }

    public void ChangeSFXVolume(float volume)
    {
        mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFX", volume);
    }

    public float GetMasterVolume()
    {
        float currentVolume;
        mixer.GetFloat("Master", out currentVolume);
        return Mathf.Pow(10, currentVolume / 20);
    }

    public float GetBGMVolume()
    {
        float currentVolume;
        mixer.GetFloat("BGM", out currentVolume);
        return Mathf.Pow(10, currentVolume / 20);
    }

    public float GetSFXVolume()
    {
        float currentVolume;
        mixer.GetFloat("SFX", out currentVolume);
        return Mathf.Pow(10, currentVolume / 20);
    }
}

// AudioClip : ���� ���� (���� �Ҹ� ������)
// AudioSource : ������� ����ϰ� �����ϴ� �� ���
// AudioListener : �Ҹ��� ��� ��Ʈ