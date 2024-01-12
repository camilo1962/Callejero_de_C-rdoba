using UnityEngine;
using UnityEngine.UI;    // �ǉ�

public class DropdownScroll : MonoBehaviour
{
  public void Start()
  {
    
    var dropdown = GetComponentInParent<Dropdown>();
    var scrollRect = gameObject.GetComponent<ScrollRect>();
    var viewport = transform.Find("Viewport").GetComponent<RectTransform>();
    var contentArea = transform.Find("Viewport/Content").GetComponent<RectTransform>();
    var contentItem = transform.Find("Viewport/Content/Item").GetComponent<RectTransform>();

    // �I�����Ă���A�C�e���̈ʒu��\���̈�����ƂɑI���A�C�e���܂ŃX�N���[�����ׂ��ʂ��v�Z����
    var areaHeight = contentArea.rect.height - viewport.rect.height;
    var cellHeight = contentItem.rect.height;
    var scrollRatio = (cellHeight * dropdown.value) / areaHeight;
    scrollRect.verticalNormalizedPosition = 1.0f - Mathf.Clamp(scrollRatio, 0.0f, 1.0f);
  }
}
