using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSystem_Gabu : MonoBehaviour
{
    #region �ϐ�
    protected bool _isButton = false;
    protected bool _isExecute = true;
    protected int _i_currentAnimation = 0;
    protected int _i_lastAnimation = 0;

    [SerializeField]
    protected Animator _animator;

    [SerializeField]
    protected Transform _transform;
    [SerializeField]
    protected Vector3 _unitPosition;
    [SerializeField]
    protected Vector3 _unitRotation;
    [SerializeField]
    protected Vector3 _unitScale;

    [SerializeField]
    protected Image _image;

    [SerializeField, Header("��{�F")]
    protected Color _imageColor;

    [SerializeField]
    protected TextMeshProUGUI _tmp;

    [SerializeField, Header("�e�L�X�g�̐F")]
    protected Color _tmpColor;

    [SerializeField, Header("�����ŐF�̍ʓx�A���x��ύX")]
    protected bool _isAutoColor = true;
    [SerializeField, Header("S(�ʓx)ga���ύX����Ȃ��Ȃ�")]
    protected bool _isMonochrome = false;

    enum AnimatorState
    {
        Normal = 0, Highlighted, Pressed, Selected, Disabled
    }
    #endregion

    #region �֐�
    /// <summary>
    /// Animator�̍Đ����̃A�j���[�V�������m�F���܂��B
    /// </summary>
    /// <returns></returns>
    protected int CheckAnimationState()
    {
        if (_isButton || _animator == null)
        {
            return (int)AnimatorState.Normal;
        }

        foreach (string state in Enum.GetNames(typeof(AnimatorState)))
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName(state))
            {
                return (int)Enum.Parse(typeof(AnimatorState), state);
            }
        }

        return (int)AnimatorState.Normal;
    }

    /// <summary>
    /// Color��H,S,V��ύX���܂�
    /// </summary>
    /// <param name="currentColor"></param>
    /// <param name="h"></param>
    /// <param name="s"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    protected Color ChengeHSV(Color currentColor, float h, float s = 0.6f, float v = 0.6f)
    {
        Color newColor;
        Color.RGBToHSV(currentColor, out newColor.r, out newColor.g, out newColor.b);
        newColor = new Color(h, s, v);
        return Color.HSVToRGB(newColor.r, newColor.g, newColor.b);
    }
    /// <summary>
    /// Color��S,V(�ʓx,���x)������ς��܂�
    /// </summary>
    /// <param name="currentColor"></param>
    /// <param name="s"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    protected Color ChengeHSV(Color currentColor, float s = 0.6f, float v = 0.6f)
    {
        Color newColor;
        Color.RGBToHSV(currentColor, out newColor.r, out newColor.g, out newColor.b);
        newColor = new Color(newColor.r, s, v);
        return Color.HSVToRGB(newColor.r, newColor.g, newColor.b);
    }

    /// <summary>
    /// Color��S(�ʓx)������ς��܂�
    /// </summary>
    /// <param name="currentColor"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    protected Color ChengeHSV(Color currentColor, float v = 0.6f)
    {
        Color newColor;
        Color.RGBToHSV(currentColor, out newColor.r, out newColor.g, out newColor.b);
        newColor = new Color(newColor.r, newColor.g, v);
        return Color.HSVToRGB(newColor.r, newColor.g, newColor.b);
    }

    /// <summary>
    /// RGB��HSV�ɕϊ��������Z���s���Ă�RGB�ɖ߂��֐��ł��B�����Z������܂�
    /// </summary>
    /// <param name="currentColor"></param>
    /// <param name="sabtractColor"></param>
    /// <returns></returns>
    protected Color SubtractionHSV(Color currentColor, Color sabtractColor)
    {
        Color.RGBToHSV(currentColor, out currentColor.r, out currentColor.g, out currentColor.b);
        Color.RGBToHSV(sabtractColor, out sabtractColor.r, out sabtractColor.g, out sabtractColor.b);
        Color newColor = currentColor - sabtractColor;
        return Color.HSVToRGB(newColor.r, newColor.g, newColor.b);
    }

    /// <summary>
    /// RGB��HSV�ɕϊ��������Z���s���Ă�RGB�ɖ߂��֐��ł��B�����Z������܂�
    /// </summary>
    /// <param name="currentColor"></param>
    /// <param name="h"></param>
    /// <param name="s"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    protected Color SubtractionHSV(Color currentColor, float h, float s, float v)
    {
        Color.RGBToHSV(currentColor, out currentColor.r, out currentColor.g, out currentColor.b);
        Color newColor = currentColor - new Color(h, s, v);
        return Color.HSVToRGB(newColor.r, newColor.g, newColor.b);
    }

    /// <summary>
    /// RGB��HSV�ɕϊ��������Z���s���Ă�RGB�ɖ߂��֐��ł��B�����Z������܂�
    /// </summary>
    /// <param name="currentColor"></param>
    /// <param name="addColor"></param>
    /// <returns></returns>
    protected Color AdditionHSV(Color currentColor, Color addColor)
    {
        Color.RGBToHSV(currentColor, out currentColor.r, out currentColor.g, out currentColor.b);
        Color.RGBToHSV(addColor, out addColor.r, out addColor.g, out addColor.b);
        Color newColor = currentColor + addColor;
        return Color.HSVToRGB(newColor.r, newColor.g, newColor.b);
    }

    /// <summary>
    /// RGB��HSV�ɕϊ��������Z���s���Ă�RGB�ɖ߂��֐��ł��B�����Z������܂�
    /// </summary>
    /// <param name="currentColor"></param>
    /// <param name="h"></param>
    /// <param name="s"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    protected Color AdditionHSV(Color currentColor, float h, float s, float v)
    {
        Color.RGBToHSV(currentColor, out currentColor.r, out currentColor.g, out currentColor.b);
        Color newColor = currentColor + new Color(h, s, v);
        return Color.HSVToRGB(newColor.r, newColor.g, newColor.b);
    }

    protected virtual void NormalAnimation()
    {
        if (_i_currentAnimation == _i_lastAnimation)
        {
            return;
        }
        _image.DOColor(_imageColor, duration: 0.4f);
        _tmp.DOColor(_tmpColor, duration: 0.4f);
        _transform.DOScale(_unitScale, duration: 0.4f);
    }
    protected virtual void HighlightedAnimation()
    {
        if (_i_currentAnimation == _i_lastAnimation)
        {
            return;
        }

        if (_isMonochrome)
        {
            _image.DOColor(AdditionHSV(_imageColor, h: 0f, s: 0.0f, v: 0.2f), duration: 0.2f);
            _tmp.DOColor(AdditionHSV(_tmpColor, h: 0f, s: 0.0f, v: 0.2f), duration: 0.2f);

            _transform.DOScale(_unitScale * 1.1f, duration: 0.2f);
        }
        else
        {
            _image.DOColor(AdditionHSV(_imageColor, h: 0f, s: 0.2f, v: 0.2f), duration: 0.2f);
            _tmp.DOColor(AdditionHSV(_tmpColor, h: 0f, s: 0.2f, v: 0.2f), duration: 0.2f);

            _transform.DOScale(_unitScale * 1.1f, duration: 0.2f);
        }
    }
    protected virtual void PressedAnimation()
    {
        if (_i_currentAnimation == _i_lastAnimation)
        {
            return;
        }

        if (_isMonochrome)
        {
            _image.DOColor(AdditionHSV(_imageColor, h: 0f, s: 0f, v: 0.1f), duration: 0f);
            _tmp.DOColor(AdditionHSV(_tmpColor, h: 0f, s: 0f, v: 0.1f), duration: 0f);

            _transform.DOScale(_unitScale * 1.05f, duration: 0f);
        }
        else
        {
            _image.DOColor(AdditionHSV(_imageColor, h: 0f, s: 0.1f, v: 0.1f), duration: 0f);
            _tmp.DOColor(AdditionHSV(_tmpColor, h: 0f, s: 0.1f, v: 0.1f), duration: 0f);

            _transform.DOScale(_unitScale * 1.05f, duration: 0f);
        }
    }
    protected virtual void SelectedAnimation()
    {
        if (_i_currentAnimation == _i_lastAnimation)
        {
            return;
        }

        if (_isMonochrome)
        {
            _image.DOColor(AdditionHSV(_imageColor, h: 0f, s: 0f, v: 0.2f), duration: 0.2f);
            _tmp.DOColor(AdditionHSV(_tmpColor, h: 0f, s: 0f, v: 0.2f), duration: 0.2f);

            _transform.DOScale(_unitScale * 1.1f, duration: 0.2f);
        }
        else
        {
            _image.DOColor(AdditionHSV(_imageColor, h: 0f, s: 0.2f, v: 0.2f), duration: 0.2f);
            _tmp.DOColor(AdditionHSV(_tmpColor, h: 0f, s: 0.2f, v: 0.2f), duration: 0.2f);

            _transform.DOScale(_unitScale * 1.1f, duration: 0.2f);
        }
    }
    protected virtual void DisabledAnimation()
    {
        if (_i_currentAnimation == _i_lastAnimation)
        {
            return;
        }

        if (_isMonochrome)
        {
            _image.DOColor(ChengeHSV(_imageColor, v: 0.4f), duration: 0.05f);
            _tmp.DOColor(ChengeHSV(_tmpColor, v: 0.4f), duration: 0.05f);

            _transform.DOScale(_unitScale, duration: 0.05f);
        }
        else
        {
            _image.DOColor(ChengeHSV(_imageColor, s: 0.4f, v: 0.4f), duration: 0.05f);
            _tmp.DOColor(ChengeHSV(_tmpColor, s: 0.4f, v: 0.4f), duration: 0.05f);

            _transform.DOScale(_unitScale, duration: 0.05f);
        }
    }
    #endregion

    protected void Start()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
        if (_transform == null)
        {
            _transform = GetComponent<Transform>();
        }
        if (_unitPosition != _transform.position)
        {
            _unitPosition = _transform.position;
        }
        if (_unitRotation != _transform.eulerAngles)
        {
            _unitRotation = _transform.eulerAngles;
        }
        if (_unitScale != _transform.localScale)
        {
            _unitScale = _transform.localScale;
        }
        if (_image == null)
        {
            _image = GetComponent<Image>();
        }
        if (_tmp == null)
        {
            _tmp = GetComponentInChildren<TextMeshProUGUI>();
        }
        if (_isAutoColor)
        {
            _imageColor = ChengeHSV(_imageColor, s: 0.65f, v: 0.7f);
            _tmpColor = ChengeHSV(_tmpColor, s: 0.65f, v: 0.7f);
        }
    }

    protected void Update()
    {
        if (_animator == null)
        {
            return;
        }

        _i_currentAnimation = CheckAnimationState();
        switch (_i_currentAnimation)
        {
            case (int)AnimatorState.Normal:
                NormalAnimation();
                break;
            case (int)AnimatorState.Highlighted:
                HighlightedAnimation();
                break;
            case (int)AnimatorState.Pressed:
                PressedAnimation();
                break;
            case (int)AnimatorState.Selected:
                SelectedAnimation();
                break;
            case (int)AnimatorState.Disabled:
                DisabledAnimation();
                break;
        }

        _i_lastAnimation = _i_currentAnimation;
    }
}
