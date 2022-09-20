using StarterAssets;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject _player;
    PlayerStats _playerStats;
    ThirdPersonController _thirdPersonController;
    StarterAssetsInputs _starterAssetsInputs;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerStats = _player.GetComponent<PlayerStats>();
        _thirdPersonController = _player.GetComponent<ThirdPersonController>();
        _starterAssetsInputs = _player.GetComponent<StarterAssetsInputs>();
    }
    private void OnTriggerEnter(Collider col)
    {
        {
            if (col.CompareTag("Player") == false) return;
            {
                _playerStats.CurrentHealth -= 1;
                _playerStats.ChangeHeathUI();

                var sphereColider = GetComponent<SphereCollider>();
                sphereColider.enabled = false;

                _thirdPersonController.isDead = true;
                _starterAssetsInputs.SetInputOnUI(false);

                var playerColider = GetComponents<SphereCollider>();
                foreach (var collider in playerColider)
                {
                    collider.isTrigger = true;
                }
            }
        }

    }
    private void OnTriggerExit(Collider col)
    {
        {
            if (col.CompareTag("Player") == false) return;

            var sphereColider = GetComponent<SphereCollider>();
            sphereColider.enabled = true;

            var playerColider = col.GetComponent<SphereCollider>();
            playerColider.isTrigger = false;
        }
    }
}
