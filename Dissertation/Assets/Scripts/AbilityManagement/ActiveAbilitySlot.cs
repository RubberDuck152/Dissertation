using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbilitySlot : MonoBehaviour
{
    public int AssignedAbilityID;
    public string AssignedAbilityClass;
    public int AssignedAbilitySubID;
    public bool ActivateEAbility;

    public GameObject AbilitiesScript;

    private void Start()
    {
        ActivateEAbility = false;
    }

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
                                AbilitiesScript.GetComponent<Shield>().ChosenShield = 0;
                                AbilitiesScript.GetComponent<Shield>().Activate = true;
                                break;
                            case 1:
                                AbilitiesScript.GetComponent<Shield>().ChosenShield = 1;
                                AbilitiesScript.GetComponent<Shield>().Activate = true;
                                break;
                            case 2:
                                AbilitiesScript.GetComponent<Shield>().ChosenShield = 2;
                                AbilitiesScript.GetComponent<Shield>().Activate = true;
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
