using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemPickupNotification : MonoBehaviour
{
    public Text text;
    public Image itemImage;

    public double fadeDuration = .1f;

    public double fadeTime = 0;

    public Vector3 imageStartPosition;
    public Vector3 imageEndPosition;

    public Vector3 textStartPosition;
    public Vector3 textEndPosition;

    public AnimationCurve animationCurve;

    private enum NotificationFadeState
    {
        FadeIn, FadeOut, Visible, Hidden
    }

    private NotificationFadeState fadeState = NotificationFadeState.Hidden;

    void Start()
    {
        text.gameObject.SetActive(false);
        text.text = "";
        itemImage.gameObject.SetActive(false);
    }

    public void ShowPickupNotification(ItemBase item)
    {
        text.gameObject.SetActive(true);
        text.text = item.GetDisplayName();
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = item.GetSprite();
        fadeState = NotificationFadeState.FadeIn;
    }

    public void ClosePickupNotification()
    {
        fadeState = NotificationFadeState.FadeOut;
    }

    public void HidePickupNotification()
    {
        text.gameObject.SetActive(false);
        text.text = "";
        itemImage.gameObject.SetActive(false);
        fadeState = NotificationFadeState.Hidden;
    }

    void Update()
    {
        switch (fadeState)
        {
            case NotificationFadeState.FadeIn:
                fadeTime += Time.deltaTime;
                UpdatePositions();
                if (ShouldChangeState())
                {
                    fadeState = NotificationFadeState.Visible;
                    fadeTime = fadeDuration;
                }
                break;

            case NotificationFadeState.FadeOut:
                fadeTime -= Time.deltaTime;
                UpdatePositions();
                if (ShouldChangeState())
                {
                    fadeState = NotificationFadeState.Hidden;
                    fadeTime = 0;
                }
                break;
        }

    }

    private void UpdatePositions()
    {
        if (IsInTransitionState())
        {
            itemImage.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(imageStartPosition, imageEndPosition, animationCurve.Evaluate((float)(fadeTime / fadeDuration)));
            text.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(textStartPosition, textEndPosition, animationCurve.Evaluate((float)(fadeTime / fadeDuration)));
        }
    }

    private bool IsInTransitionState()
    {
        return fadeState == NotificationFadeState.FadeIn || fadeState == NotificationFadeState.FadeOut;
    }

    private bool ShouldChangeState()
    {
        return fadeTime >= fadeDuration || fadeTime <= 0;
    }
}
