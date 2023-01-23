using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UISystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<PlayerHealthComponent, PlayerDataComponent> _filter = null;
    private TextMeshProUGUI _healthText;
    private TextMeshProUGUI _score;
    private Button _restart;

    public TextMeshProUGUI HealthText { get => _healthText; set => _healthText = value; }
    public TextMeshProUGUI Score { get => _score; set => _score = value; }
    public Button Restart { get => _restart; set => _restart = value; }

    public void Init()
    {
        HealthText = GameObject.Find("Canvas/Health").GetComponent<TextMeshProUGUI>();
        Score = GameObject.Find("Canvas/Score").GetComponent<TextMeshProUGUI>();
        Restart = GameObject.Find("Canvas/Restart").GetComponent<Button>();

        Restart.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }

    public void Run()
    {
        foreach(var i in _filter)
        {
            HealthText.text = _filter.Get1(i).Health.ToString("#.#");
            Score.text = _filter.Get2(i).Scores.ToString("#.#");
        }
    }
}
