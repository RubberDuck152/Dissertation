using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RawImage image;
    public Image AbilitySlot1;
    public Image AbilitySlot2;
    public Image AbilitySlot3;
    [HideInInspector] public Transform ParentAfterDrag;
    public int AssignedAbilityID;
    public string AssignedAbilityClass;

    public void OnBeginDrag(PointerEventData eventData)
    {
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentAfterDrag);
        image.raycastTarget = true;
        if (transform.parent.tag == "AbilitySlot1")
        {
            AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilityClass = AssignedAbilityClass;
            AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilityID = AssignedAbilityID;
        }

        if (transform.parent.tag == "AbilitySlot2")
        {
            AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilityClass = AssignedAbilityClass;
            AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilityID = AssignedAbilityID;
        }

        if (transform.parent.tag == "AbilitySlot3")
        {
            AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilityClass = AssignedAbilityClass;
            AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilityID = AssignedAbilityID;
        }
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().AbilityUI.activeSelf == true)
        {
            GetComponent<RawImage>().enabled = true;
        }
        else
        {
            GetComponent<RawImage>().enabled = false;
        }
    }
}
