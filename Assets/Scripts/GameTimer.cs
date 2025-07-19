using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    private float _elapsedTime = 0f;

    void Update()
    {
        _elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(_elapsedTime / 60);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60);

        _timerText.text = $"{minutes:00}:{seconds:00}";
    }
}