using TMPro;
using UnityEngine;

public class TimeAndScore : MonoBehaviour
{
    public static TimeAndScore Instance { get; private set; }
    
    [Header("Text")]
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    
    private float _timeElapsed;
    private int _score;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Instance.AddScore(0);
    }
    
    void Update()
    {
        if(PauseMenu.Instance.GetPauseState()) return;
        
        _timeElapsed += Time.deltaTime;
        timeText.text = $"{_timeElapsed / 60:00}:{_timeElapsed % 60:00}";
    }
    
    public void AddScore(int score)
    {
        _score += score;
        scoreText.text = $"{_score:0000}";
    }
    
    public float GetTimeElapsed()
    {
        return _timeElapsed;
    }
    
    public int GetScore()
    {
        return _score;
    }
}
