using UnityEngine;
using DG.Tweening;

public class Road : MonoBehaviour
{
    private void OnMouseDown()
    {
        Player.Instance.transform.DOMove(transform.position, 0.5f).SetEase(Ease.InOutQuad);
    }
}
