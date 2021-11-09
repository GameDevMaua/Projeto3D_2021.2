using UnityEngine;
using DG.Tweening;
using Player;

namespace Road
{
    public class Road : MonoBehaviour
    {
        [ContextMenu("click function")]
        private void OnMouseDown()
        {
            print("test");
            PlayerManager.Instance.transform.DOMove(transform.position, 1f).SetEase(Ease.InOutQuad);
        }
    }
}
