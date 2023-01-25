using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelectorTextManager : MonoBehaviour
{
    [SerializeField] private Text VariantSlot1;
    [SerializeField] private Text VariantSlot2;
    [SerializeField] private Text VariantSlot3;

    [SerializeField] private Text TypeSlot1;
    [SerializeField] private Text TypeSlot2;
    [SerializeField] private Text TypeSlot3;

    [SerializeField] private Text KeyBind1;
    [SerializeField] private Text KeyBind2;
    [SerializeField] private Text KeyBind3;

    [SerializeField] private Image AbilitySlot1;
    [SerializeField] private Image AbilitySlot2;
    [SerializeField] private Image AbilitySlot3;

    void Update()
    {
        TypeSlot1.text = "Type: " + AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilityClass;
        TypeSlot2.text = "Type: " + AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilityClass;
        TypeSlot3.text = "Type: " + AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilityClass;

        VariantSlot1.text = "Variant: " + AbilitySlot1.GetComponent<ActiveAbilitySlot1>().AssignedAbilitySubID;
        VariantSlot2.text = "Variant: " + AbilitySlot2.GetComponent<ActiveAbilitySlot2>().AssignedAbilitySubID;
        VariantSlot3.text = "Variant: " + AbilitySlot3.GetComponent<ActiveAbilitySlot3>().AssignedAbilitySubID;

        KeyBind1.text = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().FirstAbilityButton;
        KeyBind2.text = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().SecondAbilityButton;
        KeyBind3.text = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().ThirdAbilityButton;
    }
}
