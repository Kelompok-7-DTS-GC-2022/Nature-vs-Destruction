using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    [Header("SFX")]
    [SerializeField] AudioClip _collectEnergy;
    [SerializeField] AudioClip _click;
    [SerializeField] AudioClip _levelComplete;
    [SerializeField] AudioClip _levelLose;
    [SerializeField] AudioClip _planting;
    [SerializeField] AudioClip _ledakan;
    [SerializeField] AudioClip _attackPohon;
    [SerializeField] AudioClip _attackEnemy;

    AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("SFX") == 1)
        {
            _audioSource.mute = false;
        }
        else
        {
            _audioSource.mute = true;
        }
    }
    public void PlayCollectEnergy()
    {
        _audioSource.PlayOneShot(_collectEnergy);
    }
    public void PlayClick()
    {
        _audioSource.PlayOneShot(_click);
    }
    public void PlayLevelComplete()
    {
        _audioSource.PlayOneShot(_levelComplete);
    }
    public void PlayLevelLose()
    {
        _audioSource.PlayOneShot(_levelLose);
    }
    public void PlayPlanting()
    {
        _audioSource.PlayOneShot(_planting);
    }
    public void PlayLedakan()
    {
        _audioSource.PlayOneShot(_ledakan);
    }
    public void PlayAttackPohon()
    {
        _audioSource.PlayOneShot(_attackPohon);
    }
    public void PlayAttackEnemy()
    {
        _audioSource.PlayOneShot(_attackEnemy);
    }
}
