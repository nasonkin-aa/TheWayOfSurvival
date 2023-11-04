using System;
using UnityEngine;

[RequireComponent(typeof(HealthBase))]
public class TextWithHp : MonoBehaviour
{
    private TextMesh _hpTextMesh;
    private MoveBase _move;
    private HealthBase _hp;

    protected void Awake()
    {
        _hp = GetComponent<HealthBase>();
        _move = GetComponent<MoveBase>();
    }

    protected virtual void Start()
    {
        CreateTextWithHP();
        if (_hp is not null)
            _hp.OnHpChange += ChangeHPBar;
        if (_move is not null)
            _move.OnFlip += FlipText;
    }

    private void CreateTextWithHP()// For testing
    {
        var parent = GetComponentInParent<Root>();
        var subObj = SubObjectsCreator.CreateSubObjectWithModifier(transform, typeof(TextMesh));
        _hpTextMesh = subObj.GetComponent<TextMesh>();

        float hight = GetComponent<SpriteRenderer>().bounds.size.y / transform.localScale.y;
        subObj.transform.localPosition = new Vector2(0, hight / 2 + hight * 0.25f);
        SetUpTextMesh(_hpTextMesh);
    }

    private void SetUpTextMesh(TextMesh text)
    {
        text.text = _hp.Health.ToString() + '/' + _hp.MaxHealth;
        text.fontSize = 25;
        text.characterSize = 0.2f;
        text.anchor = TextAnchor.MiddleCenter;
    }

    protected virtual void FlipText()
    {
        var sign = Mathf.Sign(transform.localScale.x);
        var scale = _hpTextMesh.transform.localScale;
        _hpTextMesh.transform.localScale = new Vector2(MathF.Abs(scale.x) * sign, scale.y);
    }

    private void ChangeHPBar(int hp)
    {
        _hpTextMesh.text = _hp.Health.ToString() + '/' + _hp.MaxHealth;
    }
}
