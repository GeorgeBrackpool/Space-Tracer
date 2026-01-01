using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Text healthText;
    FingerMovement player;
    InvulnerabilityDisplay invulnerabilityDisplay;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        player = FindObjectOfType<FingerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
            healthText.text = player.GetHealth().ToString();
        
    }
}
