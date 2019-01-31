using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class hoge3 : MonoBehaviour {

    [SerializeField]
    private GameObject _text;
    [SerializeField]
    private Text text1;
    [SerializeField]
    private GameObject buttonMgr;
    private bool notcount;

    private float titleStart;
    private bool SceneEnd_flg;

    public AudioClip checksound;
    private AudioSource _audioSource;

    void Start ()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
	}

    void Update()
    {
        if (SceneEnd_flg)
        {
            titleStart += Time.deltaTime;
        }
        if (titleStart >= 4)
        {
            Debug.Log("end");
            Application.Quit();
        }
    }
    public void HeardButtonClicked()
    {
        _audioSource.PlayOneShot(checksound);
        SceneManager.LoadScene("mainScene");
    }
    public void NormalButtonClicked()
    {
        _audioSource.PlayOneShot(checksound);
        SceneManager.LoadScene("");
    }
    public void EasyButtonClicked()
    {
        _audioSource.PlayOneShot(checksound);
        SceneManager.LoadScene("");
    }
    public void EndButtonClicked()
    {
        _audioSource.PlayOneShot(checksound);
        buttonMgr.SetActive(false);
        text1.text = "aaaaaaa";
        SceneEnd_flg = true;
    }
}