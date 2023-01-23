using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbilitySlot : MonoBehaviour
{
    public int AssignedAbilityID;
    public string AssignedAbilityClass;
    public int AssignedAbilitySubID;
    public bool ActivateEAbility = false;

    void Update()
    {
        if (ActivateEAbility == true)
        {
            if (AssignedAbilityClass == "Tank")
            {
                switch (AssignedAbilityID)
                {
                    case 0:
                        switch(AssignedAbilitySubID)
                        {
                            case 0:
                                GetComponent<Shield>().ChosenShield = 0;
                                break;
                            case 1:
                                GetComponent<Shield>().ChosenShield = 1;
                                break;
                            case 2:
                                GetComponent<Shield>().ChosenShield = 2;
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
