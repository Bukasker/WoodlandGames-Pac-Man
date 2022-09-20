using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] List<GameObject> seedList;
    public int _currentSeed;

    [Header("Game Menu")]
    [SerializeField] GameUI _gameUI;
    [Header("RespawnPoint")]
    [SerializeField] GameObject _respawnPoint;
    [Header("Enemies")]
    [SerializeField] GameObject[] _enemy;

    GameObject _player;
    ThirdPersonController _thirdPersonController;
    StarterAssetsInputs _starterAssetsInputs;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _thirdPersonController = _player.GetComponent<ThirdPersonController>();
        _starterAssetsInputs = _player.GetComponent<StarterAssetsInputs>();
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Seed"))
        {
            seedList.Add(fooObj);
        }
        _currentSeed = seedList.Count;
    }
    private void Update()
    {
        if(_currentSeed == 0)
        {
            _gameUI.SetWinUI(true);
            _starterAssetsInputs.SetInputOnUI(false);
        }
    }
    public void SubtractSeed()
    {
        _currentSeed -= 1;
    }

    public void Respawn()
    {
        StartCoroutine("TeleportTo");
        _thirdPersonController.isDead = false;
        _starterAssetsInputs.SetInputOnUI(true); ;
    }
    private IEnumerator TeleportTo()
    {
        _thirdPersonController.enabled = false;
        yield return new WaitForSeconds(0.3f);
        _player.transform.position = new Vector3(_respawnPoint.transform.position.x, _respawnPoint.transform.position.y + 3f, _respawnPoint.transform.position.z);
        yield return new WaitForSeconds(0.3f);
        _thirdPersonController.enabled = true;
        foreach (var enemies in _enemy)
        {
            var sphereColider = enemies.GetComponent<SphereCollider>();
            sphereColider.enabled = true;
        }
    }
}
