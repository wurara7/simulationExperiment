using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glinting : MonoBehaviour
{
    /// <summary>
    /// ��˸��ɫ,���,�߷������ȣ���˸Ƶ�ʣ�
    /// </summary>
    public Color color = new Color(255, 120, 59, 255);
    [Range(0.0f, 1.0f)]
    public float minBrightness = 0.0f;
    [Range(0.0f, 1)]
    public float maxBrightness = 0.5f;
    [Range(0.2f, 30.0f)]
    public float rate = 1;

    [Tooltip("��ѡ����������ʱ�Զ���ʼ��˸")]
    [SerializeField]
    private bool _autoStart = false;

    private float _h, _s, _v;           // ɫ�������Ͷȣ�����
    private float _deltaBrightness;     // ���������Ȳ�
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
    /// ��ʼ��˸��
    /// </summary>
    
    public void StartGlinting()
    {
        print("����");
        _material.EnableKeyword(_keyword);

        if (_glinting != null)
        {
            StopCoroutine(_glinting);
        }
        _glinting = StartCoroutine(IEGlinting());
    }

    /// <summary>
    /// ֹͣ��˸��
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
    /// �����Է���ǿ�ȡ�
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
    /// �ж��Ƿ�ص�
    /// </summary>
    
    public bool isAutoStart()
    {
       return _autoStart;
    }
    void Update()
    {
        
    }
}
