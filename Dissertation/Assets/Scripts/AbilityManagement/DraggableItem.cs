using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform ParentAfterDrag;
    bool collisionSlot = false;
    public int AssignedAbilityID;
    public string AssignedAbilityClass;
    Collision lastCollision;

    public void OnBeginDrag(PointerEventData eventData)
    {
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentAfterDrag);
        if (collisionSlot == true)
        {
            lastCollision.gameObject.GetComponent<ActiveAbilitySlot>().AssignedAbilityID = AssignedAbilityID;
            lastCollision.gameObject.GetComponent<ActiveAbilitySlot>().AssignedAbilityClass = AssignedAbilityClass;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ActiveAbilitySlot")
        {
            collisionSlot = true;
            lastCollision = collision;
        }
    }
}
