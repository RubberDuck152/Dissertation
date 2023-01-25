using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityVariantSlider : MonoBehaviour
{
    [SerializeField] private Slider Slider1;
    [SerializeField] private Slider Slider2;
    [SerializeField] private Slider Slider3;

    [SerializeField] private Image AbilitySlot1;
    [SerializeField] private Image AbilitySlot2;
    [SerializeField] private Image AbilitySlot3;

    [SerializeField] private int ActiveSlot;

    void Update()
    {
        switch (ActiveSlot)
        {
            case 0:
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilitySubID = (int)Slider1.value;
                break;
            case 1:
                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilitySubID = (int)Slider2.value;
                break;
            case 2:
                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilitySubID = (int)Slider3.value;
                break;
        }
    }
}
