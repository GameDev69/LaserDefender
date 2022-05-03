using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    private TextMeshProUGUI _heathText;
    private Player _player;

    public void SetHealthText(int heath)
    {
        if (_heathText == null)
        {
            _heathText = GetComponent<TextMeshProUGUI>();
        }
        if (heath < 0)
        {
            heath = 0;
        }
        _heathText.text = heath.ToString();
    }
}
