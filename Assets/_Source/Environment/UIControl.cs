using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIControl : MonoBehaviour
{
    [SerializeField] CanvasGroup _finishPanel;
    [SerializeField] CanvasGroup _justBlackPanel;
    [SerializeField] List<RectTransform> buttonTransforms;
    private Game _game;

    public Game Game { get => _game; set => _game = value; }

    public void ShowEndPanel(bool value)
    {
        StartCoroutine(ShowFinishPanelsCoroutine(value));
    }
    public void ShowMenuButtons(bool value)
    {
        StartCoroutine(ShowMenuButtonsCoroutine(value));
    }
    public void HideJustBlackPanel()
    {
        StartCoroutine(HideJustBlackPanelCoroutine());
    }

    private IEnumerator ShowFinishPanelsCoroutine(bool value)
    {
        if (value)
        {
            _finishPanel.interactable = true;
            while (_finishPanel.alpha < 1)
            {
                _finishPanel.alpha += 0.04f;
                yield return new WaitForSeconds(0.08f);
            }
            _justBlackPanel.alpha = 1;
        }
        else
        {
            _finishPanel.interactable = false;
            while (_finishPanel.alpha > 0)
            {
                _finishPanel.alpha -= 0.04f;
                yield return new WaitForSeconds(0.08f);
            }
            _game.LoadMainMenu();
        }
        yield return null;
    }
    private IEnumerator ShowMenuButtonsCoroutine(bool value)
    {
        if (value)
        {
            foreach (RectTransform button in buttonTransforms)
            {
                button.GetComponent<Button>().interactable = true;
                button.DOLocalMoveX(button.localPosition.x + 550, 1).SetEase(Ease.InOutBack);
                yield return new WaitForSeconds(0.2f);
            }
        }
        else
        {
            foreach (RectTransform button in buttonTransforms)
            {
                button.GetComponent<Button>().interactable = false;
                button.DOLocalMoveX(button.localPosition.x - 550, 1).SetEase(Ease.InOutBack);
                yield return new WaitForSeconds(0.2f);
            }
        }
        yield return null;
    }
    private IEnumerator HideJustBlackPanelCoroutine()
    {
        while (_justBlackPanel.alpha > 0)
        {
            _justBlackPanel.alpha -= 0.03f;
            yield return new WaitForSeconds(0.06f);
        }
    }

    public void OnStartButtonClick()
    {
        _game.StartLevel();
    }

    public void OnMenuButtonClick()
    {
        ShowEndPanel(false);
    }
}
