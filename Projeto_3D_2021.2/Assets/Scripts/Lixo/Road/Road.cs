using UnityEngine;
using DG.Tweening;

namespace Road
{
    public class Road : MonoBehaviour
    {
        [ContextMenu("click function")]
        private void OnMouseDown()
        {
            print("test");
            Player.Instance.transform.DOMove(transform.position, 1f).SetEase(Ease.InOutQuad);
        }
    }
}
