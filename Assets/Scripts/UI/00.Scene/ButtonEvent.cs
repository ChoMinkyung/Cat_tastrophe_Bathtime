using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        // ���콺�� ��ư ���� �÷��� �� ȣ��Ǵ� �̺�Ʈ
        SoundManager.Instance.PlaySFX("Hover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ���콺�� ��ư���� ��� �� ȣ��Ǵ� �̺�Ʈ
    }
}
