using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    private TextMeshProUGUI _healthText;
    private Player _player;
    void Start()
    {
        _healthText = gameObject.GetComponent<TextMeshProUGUI>();
        _player = FindObjectOfType<Player>();
    }
    
    void Update()
    {
        _healthText.text = _player.GetHealth().ToString();
    }
}
