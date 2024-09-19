using System.Collections.Generic;
using Advertisement;
using UnityEngine;
using UnityEngine.UI;

public class Reroll : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private DrawModifier drawModifier;
    [SerializeField] private List<Button> buttons;

    private IShowAd _showAd;

    private void Awake()
    {
        gameObject.AssignComponentIfUnityNull(ref button);
        gameObject.AssignIfUnityNull(ref drawModifier, FindObjectOfType<DrawModifier>);
        _showAd = GameLogic.Instance.ShowAd;
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClick);
        _showAd.RewardVideoRewardedEvent += OnRewardVideoRewarded;
    }
    
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClick);
        _showAd.RewardVideoRewardedEvent -= OnRewardVideoRewarded;
    }

    private void OnButtonClick()
    {
        buttons.ForEach(x => x.interactable = false);
        _showAd.ShowRewardVideo();
    }

    private void OnRewardVideoRewarded()
    {
        buttons.ForEach(x => x.interactable = true);
        drawModifier.DrawNewModifier();
    }
}
