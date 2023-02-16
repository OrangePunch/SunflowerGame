using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _seedsAmountText;
    [SerializeField] private TextMeshProUGUI _enemiesText;

    public float _seedsAmount;
    public float _enemiesAmount;
    public bool _isGameActive;

    private GameSession _session;
    private MainMenu _menu;

    private void Start()
    {
        _session = FindObjectOfType<GameSession>().GetComponent<GameSession>();
        _menu = GetComponent<MainMenu>();
    }

    public void UpdateSeedsAmount()
    {
        _seedsAmount = _session.Data.Seeds;
        _seedsAmountText.text = ": " + _seedsAmount;
    }

    public void UpdateEnemiesAmount()
    {
        _enemiesAmount = _session.Data.Enemies;
        _enemiesText.text = ": " + _enemiesAmount;
    }
}
