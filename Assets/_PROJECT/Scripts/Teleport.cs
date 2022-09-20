using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _outTeleportTranform;

    private GameObject _player;
    private Transform _playerTranfsform;
    private ThirdPersonController _thirdPersonController;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerTranfsform = _player.GetComponent<Transform>();
        _thirdPersonController = _player.GetComponent<ThirdPersonController>();
    }

    private void OnTriggerEnter(Collider col)
    {
        {
            if (col.CompareTag("Player") == false) return;
            StartCoroutine("TeleportTo");
        }
    }

    private IEnumerator TeleportTo()
    {
        _thirdPersonController.enabled = false;
        yield return new WaitForSeconds(0.3f);
        _playerTranfsform.position = new Vector3(_outTeleportTranform.position.x, _outTeleportTranform.position.y + 1f, _outTeleportTranform.position.z);
        yield return new WaitForSeconds(0.3f);
        _thirdPersonController.enabled = true;
    }
}
