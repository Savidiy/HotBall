using System;
using HotBall;
using UnityEngine;
using UnityEngine.UI;

public sealed class HealthUI : MonoBehaviour
{
    [SerializeField] private Player player; 
    [SerializeField] private Image bar;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color poisonColor;
    
    void Awake()
    {
        if (player == null || bar == null)
            throw new Exception($"You must add the fields in the editor for {name}.");
        player.OnHealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        bar.fillAmount = player.GetNormalizedHealth;
        bar.color = player.IsPoisoned ? poisonColor : normalColor;
    }
}
