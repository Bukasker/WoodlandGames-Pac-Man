using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int Hearths = 3;
    public int CurrentHealth;

    public int Points;

    [SerializeField] Image[] _hearts;
    [SerializeField] Sprite _EmptyHeath;

    private void Awake()
    {
        CurrentHealth = Hearths;
    }
    public void ChangeHeathUI()
    {
        _hearts[CurrentHealth].sprite = _EmptyHeath;
    }
}
