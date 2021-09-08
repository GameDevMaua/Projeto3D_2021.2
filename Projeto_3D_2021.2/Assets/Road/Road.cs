using UnityEngine;
using DG.Tweening;

public class Road : MonoBehaviour
{
    [ContextMenu("click function")]
    private void OnMouseDown()
    {
        print("test");
        Player.Instance.transform.DOMove(transform.position, 1f).SetEase(Ease.InOutQuad);
    }
}
