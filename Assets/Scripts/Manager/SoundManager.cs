using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
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
            Debug.LogWarning(bgmSound + "�� ã�� �� ����");
        }
        else
        {
            if (bgmSource != null)
            {
                bgmSource.clip = bgmSound.audioClip;
                bgmSource.loop = true;
                bgmSource.Play();
            }
            else
            {
                Debug.LogWarning("bgmSource�� null�Դϴ�. AudioSource ������Ʈ�� Ȯ�����ּ���.");
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
        }
    }

    public void StopBGM()
    {
        if(bgmSource != null)
            bgmSource.Stop();
    }

    public void ToggleBGM()
    {
        bgmSource.mute = !bgmSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void ChangeBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void ChangeSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }    
}

// AudioClip : ���� ���� (���� �Ҹ� ������)
// AudioSource : ������� ����ϰ� �����ϴ� �� ���
// AudioListener : �Ҹ��� ��� ��Ʈ