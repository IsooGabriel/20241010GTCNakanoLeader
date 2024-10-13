using DG.Tweening;

public class WhiteUIAnimation_Gabu : AnimationSystem_Gabu
{
    protected override void NormalAnimation()
    {
        if (_i_currentAnimation == _i_lastAnimation)
        {
            return;
        }
        _image.DOColor(_imageColor, duration: 0.4f);
        _tmp.DOColor(_tmpColor, duration: 0.4f);
        _transform.DOScale(_unitScale, duration: 0.4f);
    }

    protected override void HighlightedAnimation()
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
}
