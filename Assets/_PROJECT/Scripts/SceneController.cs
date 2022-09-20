using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    GameObject _player;
    StarterAssetsInputs _starterAssetsInputs;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if( _player == null )
        _starterAssetsInputs = _player.GetComponent<StarterAssetsInputs>();
    }
    public void LoadTheScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        _starterAssetsInputs.cursorLocked = true;
        _starterAssetsInputs.cursorInputForLook = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
