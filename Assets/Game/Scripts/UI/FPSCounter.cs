using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI fpsText;

    private int _frameCount;
    private float _deltaTime;
    private const int FrameRange = 240;

    void Update()
    {
        if(PauseMenu.Instance.GetPauseState()) return;
        
        _frameCount++;
        _deltaTime += Time.smoothDeltaTime;

        if (_frameCount >= FrameRange)
        {
            float averageFPS = FrameRange / _deltaTime;
            fpsText.text = $"{averageFPS:0} FPS";
            _frameCount = 0;
            _deltaTime = 0.0f;
        }
    }
}