using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Seed : MonoBehaviour
{
    private GameObject _player;
    private PlayerStats _playerStats;

    private GameObject _gameMenager;
    private GameLogic _gameLogic;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerStats = _player.GetComponent<PlayerStats>();

        _gameMenager = GameObject.FindGameObjectWithTag("GameMenager");
        _gameLogic = _gameMenager.GetComponent<GameLogic>();
    }

    private void OnTriggerEnter(Collider col)
    {
        {
            if (col.CompareTag("Player") == false) return;

            _gameLogic.SubtractSeed();
            _playerStats.Points += 10;
            Destroy(gameObject);
        }
    }
}
