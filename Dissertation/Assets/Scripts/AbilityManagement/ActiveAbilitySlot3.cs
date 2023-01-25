using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbilitySlot3 : MonoBehaviour
{
    public int AssignedAbilityID;
    public string AssignedAbilityClass;
    public int AssignedAbilitySubID;
    public bool ActivateAbility;
    public bool dropdowntoggle;

    public GameObject AbilitiesScript;

    private void Start()
    {
        ActivateAbility = false;
    }

    [System.Obsolete]
    void Update()
    {
        if (dropdowntoggle == false)
        {
            if (transform.GetChildCount() == 0)
            {
                AssignedAbilityClass = null;
            }
        }

        if (ActivateAbility == true)
        {
            if (AssignedAbilityClass == "Tank")
            {
                switch (AssignedAbilityID)
                {
                    case 0:
                        switch (AssignedAbilitySubID)
                        {
                            case 0:
                                AbilitiesScript.GetComponent<DomeShield>().Activate = true;
                                ActivateAbility = false;
                                break;
                            case 1:
                                AbilitiesScript.GetComponent<WallShield>().Activate = true;
                                ActivateAbility = false;
                                break;
                            case 2:
                                AbilitiesScript.GetComponent<BubbleShield>().Activate = true;
                                ActivateAbility = false;
                                break;
                        }
                        break;
                }
            }
            else if (AssignedAbilityClass == "Healing")
            {
            }
            else if (AssignedAbilityClass == "Damage")
            {
            }
            else if (AssignedAbilityClass == "Mobility")
            {
            }
            else if (AssignedAbilityClass == "Utility")
            {
            }
        }
    }
}
