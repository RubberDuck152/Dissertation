using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownMenu : MonoBehaviour
{
    [SerializeField] private Dropdown Dropmenu;
    [SerializeField] private Image AbilitySlot1;
    [SerializeField] private Image AbilitySlot2;
    [SerializeField] private Image AbilitySlot3;

    [SerializeField] private Slider Slider1;
    [SerializeField] private Slider Slider2;
    [SerializeField] private Slider Slider3;

    [System.Obsolete]
    void Update()
    {
        if (Dropmenu.value == 0 && AbilitySlot1.transform.GetChildCount() == 0)
        {
            AbilitySlot1.GetComponent<ActiveAbilitySlot1>().dropdowntoggle = false;
            AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilitySubID = 0;
            Slider1.value = AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilitySubID;
            AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilityID = 0;
            AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilityClass = null; 
        }

        if (Dropmenu.value == 0 && AbilitySlot2.transform.GetChildCount() == 0)
        {
            AbilitySlot2.GetComponent<ActiveAbilitySlot2>().dropdowntoggle = false;
            AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilitySubID = 0;
            Slider2.value = AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilitySubID;
            AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilityID = 0;
            AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilityClass = null;
        }

        if (Dropmenu.value == 0 && AbilitySlot3.transform.GetChildCount() == 0)
        {
            AbilitySlot3.GetComponent<ActiveAbilitySlot3>().dropdowntoggle = false;
            AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilitySubID = 0;
            Slider3.value = AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilitySubID;
            AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilityID = 0;
            AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilityClass = null;
        }
        switch (Dropmenu.value)
        {
            case 1:
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().dropdowntoggle = true;
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilitySubID = 0;
                Slider1.value = AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilitySubID;
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilityID = 0;
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilityClass = "Tank";

                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().dropdowntoggle = true;
                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilitySubID = 1;
                Slider2.value = AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilitySubID;
                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilityID = 0;
                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilityClass = "Tank";

                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().dropdowntoggle = true;
                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilitySubID = 2;
                Slider3.value = AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilitySubID;
                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilityID = 0;
                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilityClass = "Tank";
                break;
            case 2:
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().dropdowntoggle = true;
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilitySubID = 0;
                Slider1.value = AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilitySubID;
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilityID = 0;
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilityClass = "Damage";

                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().dropdowntoggle = true;
                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilitySubID = 1;
                Slider2.value = AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilitySubID;
                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilityID = 0;
                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilityClass = "Damage";

                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().dropdowntoggle = true;
                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilitySubID = 2;
                Slider3.value = AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilitySubID;
                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilityID = 0;
                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilityClass = "Damage";
                break;
            case 3:
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().dropdowntoggle = true;
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilitySubID = 0;
                Slider1.value = AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilitySubID;
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilityID = 0;
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilityClass = "Healing";

                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().dropdowntoggle = true;
                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilitySubID = 1;
                Slider2.value = AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilitySubID;
                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilityID = 0;
                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilityClass = "Healing";

                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().dropdowntoggle = true;
                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilitySubID = 2;
                Slider3.value = AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilitySubID;
                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilityID = 0;
                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilityClass = "Healing";
                break;
        }
    }
}
