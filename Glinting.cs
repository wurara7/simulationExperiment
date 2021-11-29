using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glinting : MonoBehaviour
{
    /// <summary>
    /// 闪烁颜色,最低,高发光亮度，闪烁频率，
    /// </summary>
    public Color color = new Color(255, 120, 59, 255);
    [Range(0.0f, 1.0f)]
    public float minBrightness = 0.0f;
    [Range(0.0f, 1)]
    public float maxBrightness = 0.5f;
    [Range(0.2f, 30.0f)]
    public float rate = 1;

    [Tooltip("勾选此项则启动时自动开始闪烁")]
    [SerializeField]
    private bool _autoStart = false;

    private float _h, _s, _v;           // 色调，饱和度，亮度
    private float _deltaBrightness;     // 最低最高亮度差
    private Renderer _renderer;
    private Material _material;
    private readonly string _keyword = "_EMISSION";
    private readonly string _colorName = "_EmissionColor";

    private Coroutine _glinting;
    private void Start()
    {
        _renderer = gameObject.GetComponent<Renderer>();
        _material = _renderer.material;

        if (_autoStart)
        {
            StartGlinting();
        }
    }
    /// <summary>
    /// 开始闪烁。
    /// </summary>
    
    public void StartGlinting()
    {
        print("发光");
        _material.EnableKeyword(_keyword);

        if (_glinting != null)
        {
            StopCoroutine(_glinting);
        }
        _glinting = StartCoroutine(IEGlinting());
    }

    /// <summary>
    /// 停止闪烁。
    /// </summary>
    public void StopGlinting()
    {
        if(_material != null)
        _material.DisableKeyword(_keyword);

        if (_glinting != null)
        {
            StopCoroutine(_glinting);
        }
    }


    /// <summary>
    /// 控制自发光强度。
    /// </summary>
    private IEnumerator IEGlinting()
    {
        Color.RGBToHSV(color, out _h, out _s, out _v);
        _v = minBrightness;
        _deltaBrightness = maxBrightness - minBrightness;

        bool increase = true;
        while (true)
        {
            if (increase)
            {
                _v += _deltaBrightness * Time.deltaTime * rate;
                increase = _v <= maxBrightness;
            }
            else
            {
                _v -= _deltaBrightness * Time.deltaTime * rate;
                increase = _v <= minBrightness;
            }
            _material.SetColor(_colorName, Color.HSVToRGB(_h, _s, _v));
            //_renderer.UpdateGIMaterials();
            yield return null;
        }
    }

    /// <summary>
    /// 判断是否关灯
    /// </summary>
    
    public bool isAutoStart()
    {
       return _autoStart;
    }
    void Update()
    {
        
    }
}
