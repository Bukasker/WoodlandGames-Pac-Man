using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [Header("Menu Canvas")]
    [SerializeField] GameObject _respawnUI;
    [SerializeField] GameObject _resetUI;
    [SerializeField] GameObject _WinUI;

    GameObject _player;
    ThirdPersonController _thirdPersonController;
    PlayerStats _playerStats;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _thirdPersonController = _player.GetComponent<ThirdPersonController>();
        _playerStats = _player.GetComponent<PlayerStats>();
        _WinUI.SetActive(false);
    }
    private void Update()
    {
        if(_playerStats.CurrentHealth > 0 && _thirdPersonController.isDead)
        {
            _respawnUI.SetActive(true);
        }
        else if( _playerStats.CurrentHealth <= 0 && _thirdPersonController.isDead)
        {
            _resetUI.SetActive(true);
        }
        else
        {
            _respawnUI.SetActive(false);
            _resetUI.SetActive(false);
        }
    }
    public void SetWinUI(bool newSet)
    {
        _WinUI.SetActive(newSet);
    }
}
