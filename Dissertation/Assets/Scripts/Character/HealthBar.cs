using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthBar;
    public CharacterMovement player;

    void Update()
    {
        healthBar.text = "Health: " + player.CurrentPlayerHP + " | " + player.MaxPlayerHP;
    }
}
