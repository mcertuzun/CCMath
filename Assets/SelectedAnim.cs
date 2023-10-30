using DG.Tweening;
using TMPro;
using UnityEngine;

public class SelectedAnim : MonoBehaviour
{
    private Sequence _sequence;

    private void Start()
    {
        _sequence = DOTween.Sequence();
    }

    public void OnSelectedAnim()
    {
        if (_sequence.IsPlaying()) return;
        _sequence.Insert(0, transform.DOPunchScale(new Vector3(0.25f, 0.25f, 0.25f), 0.25f, 1));
        _sequence.Insert(0, GetComponent<TextMeshPro>().DOColor(Color.gray, .25f).OnKill(() =>
        {
            GetComponent<TextMeshPro>().DOColor(Color.white, .25f);
        }));
        _sequence.Play();
    }
}