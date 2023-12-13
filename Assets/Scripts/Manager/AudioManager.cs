using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;

    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;

    void Start()
    {
        instance = this;
    }

    public void PlayBGM(string p_bgmame)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if(p_bgmame == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
            }
        }
    }


    public void StopBGM()
    {
        bgmPlayer.Stop();
    }
    public void PlaySFX(string p_sfxname)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (p_sfxname == sfx[i].name)
            {
                for (int x = 0; x < sfxPlayer.Length; x++)
                {
                    if (!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfx[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }

                Debug.Log("��� ����� �÷��̾ ������Դϴ�.");
                return;

            }
        }

        Debug.Log(p_sfxname + "�̸��� ȿ������ �����ϴ�.");
    }


}
