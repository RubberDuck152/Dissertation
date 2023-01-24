using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
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
            AbilitySlot1.GetComponent<ActiveAbilitySlot>().AssignedAbilityClass = AssignedAbilityClass;
            AbilitySlot1.GetComponent<ActiveAbilitySlot>().AssignedAbilityID = AssignedAbilityID;
        }

        if (transform.parent.tag == "AbilitySlot2")
        {
            AbilitySlot2.GetComponent<ActiveAbilitySlot>().AssignedAbilityClass = AssignedAbilityClass;
            AbilitySlot2.GetComponent<ActiveAbilitySlot>().AssignedAbilityID = AssignedAbilityID;
        }

        if (transform.parent.tag == "AbilitySlot3")
        {
            AbilitySlot3.GetComponent<ActiveAbilitySlot>().AssignedAbilityClass = AssignedAbilityClass;
            AbilitySlot3.GetComponent<ActiveAbilitySlot>().AssignedAbilityID = AssignedAbilityID;
        }
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().AbilityUI.activeSelf == true)
        {
            GetComponent<Image>().enabled = true;
        }
        else
        {
            GetComponent<Image>().enabled = false;
        }
    }
}
