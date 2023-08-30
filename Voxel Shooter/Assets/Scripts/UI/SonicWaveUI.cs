using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SonicWaveUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _countDownText;
    [SerializeField] private Image _overlapImage;
    [SerializeField] private SonicWave _sonicWaveScript;

    [SerializeField] private RectTransform _overlapImageSize;
    [SerializeField] private bool _canLerp;

    private float _duration;
    private float _elapsedTime;
    private float _lerpedY;

    private float _height;
    private float _width;

    private void OnEnable() {
        EventManager.OnSonicWaveCasted.AddListener(CanLerp);
    }

    private void OnDisable() {
        EventManager.OnSonicWaveCasted.RemoveListener(CanLerp);
    }

    void Start()
    {        
        ReferenceManager.Instance.Player.TryGetComponent<SonicWave>(out _sonicWaveScript);

        _overlapImageSize = _overlapImage.transform as RectTransform;
        _duration = _sonicWaveScript.GetInitTime();
        _height = _overlapImageSize.sizeDelta.y;
        _width = _overlapImageSize.sizeDelta.x;
        _overlapImageSize.sizeDelta = new Vector2(_width, 0);
        _canLerp = false;
    }
    
    void Update()
    {
        RefreshCountDownText();
    }

    private void RefreshCountDownText() {
        _countDownText.text = _sonicWaveScript.GetCurrentTime().ToString("0.00"); //formátování čísla ve formě textu na dvě desetinná místa
        RefreshOverlapImage();
    }

    private void RefreshOverlapImage() {
        if(!_canLerp) return;

        _elapsedTime += Time.deltaTime;
        float percentageComplete = _elapsedTime / _duration;

        _lerpedY = Mathf.Lerp(_height, 0, percentageComplete);
        _overlapImageSize.sizeDelta = new Vector2(_width, _lerpedY);


        if(_lerpedY <= 0) {
            _elapsedTime = 0;
            _canLerp = false;
        }
    }

    private void CanLerp(bool value) {
        _canLerp = value;
    }
 
}
