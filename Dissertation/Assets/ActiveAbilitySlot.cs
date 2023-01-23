using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbilitySlot : MonoBehaviour
{
    public int AssignedAbilityID;
    public string AssignedAbilityClass;
    public int CurrentOptions;

    void Update()
    {
        if (AssignedAbilityClass == "Tank")
        {
            CurrentOptions = GetComponent<AbilityManager>().TankAbilities[AssignedAbilityID];
        }
        else if (AssignedAbilityClass == "Healing")
        {
            CurrentOptions = GetComponent<AbilityManager>().HealerAbilities[AssignedAbilityID];
        }
        else if (AssignedAbilityClass == "Damage")
        {
            CurrentOptions = GetComponent<AbilityManager>().DamageAbilities[AssignedAbilityID];
        }
        else if (AssignedAbilityClass == "Mobility")
        {
            CurrentOptions = GetComponent<AbilityManager>().MobilityAbilities[AssignedAbilityID];
        }
        else if (AssignedAbilityClass == "Utility")
        {
            CurrentOptions = GetComponent<AbilityManager>().UtilityAbilities[AssignedAbilityID];
        }
    }
}
