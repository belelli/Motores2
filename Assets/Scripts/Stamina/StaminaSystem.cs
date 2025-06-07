using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    [SerializeField] private int _maxStamina = 10;
    int _currentStamina;
    [SerializeField] private float _rechargeTime = 10f;
    [SerializeField] private TextMeshProUGUI _staminaText, _timerText;
    private bool _recharging;

    private DateTime _nextStaminaTime, _lastStaminaTime;

    private void Awake()
    {
        LoadData();
    }

    private void Start()
    {
        StartCoroutine(RecharginStamina());
    }
    
    void SaveData()
    {
        PlayerPrefs.SetInt("CurrencyKey", _currentStamina);
        PlayerPrefs.SetString("NextStaminaKey", _nextStaminaTime.ToString());
        PlayerPrefs.SetString("LastStaminaKey", _lastStaminaTime.ToString());
    }
    
    void LoadData()
    {
        _currentStamina = PlayerPrefs.GetInt("CurrencyKey", _maxStamina); 
        _nextStaminaTime = StringToDateTime(PlayerPrefs.GetString("NextStaminaKey"));
        _lastStaminaTime = StringToDateTime(PlayerPrefs.GetString("LastStaminaKey"));
    }

    DateTime GetActualTimeData() => DateTime.Now;

    DateTime StringToDateTime(string time)
    {
        if (string.IsNullOrEmpty(time))
        {
            return GetActualTimeData();
        }
        else
        {
            return DateTime.Parse(time);
        }
    }
    

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveData();
        }
    }

    void UpdateStamina()
    {
        _staminaText.text = _currentStamina.ToString()+"/"+_maxStamina.ToString();
    }

    void UpdateTimer()
    {
        if (_currentStamina >= _maxStamina)
        {
            _timerText.text = "Full Stamina";
        }
        
        TimeSpan timer = _nextStaminaTime - DateTime.Now;
        _timerText.text = timer.Minutes.ToString("00") + ":"+timer.Seconds.ToString("00");
    }

    public void UseStamina(int staminaToUse)
    {
        if (HasEnoughStamina(staminaToUse))
        {
            _currentStamina -= staminaToUse;
            UpdateStamina();
            if (!_recharging)
            {
                _nextStaminaTime = AddDuration(GetActualTimeData(), _rechargeTime);
                //asdsadsa
                StartCoroutine(RecharginStamina());
            }
        }
        else
        {
            Debug.Log("Platita");
        }
    }

    DateTime AddDuration(DateTime time, float duration)
    {
        return time.AddSeconds(duration);
    }
    
    IEnumerator RecharginStamina()
    {
        _recharging = true;
        UpdateTimer();
        UpdateStamina();
        while (_currentStamina < _maxStamina)
        {
            DateTime currentTime = GetActualTimeData();
            DateTime nextTime = _nextStaminaTime;

            bool hasAddedStamina = false;

            while (currentTime > nextTime)
            {
                if (_currentStamina >= _maxStamina) break;
                _currentStamina++;
                hasAddedStamina = true;
                UpdateStamina();


                DateTime timeToAdd = nextTime;

                if (_lastStaminaTime > nextTime)
                {
                    timeToAdd = _lastStaminaTime;
                }
                nextTime = AddDuration(timeToAdd, _rechargeTime);
                
            }
            
            if (hasAddedStamina)
            {
                _nextStaminaTime = nextTime;
                _lastStaminaTime = GetActualTimeData();
            }
            UpdateTimer();
            UpdateStamina();
            SaveData();
            yield return null;
        }
        _recharging = false;
    }

    bool HasEnoughStamina(int staminaToUse)
    {
        return (_currentStamina - staminaToUse >= 0);
    }
    
}
