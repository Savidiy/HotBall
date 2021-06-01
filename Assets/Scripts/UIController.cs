using System;
using System.Collections.Generic;
using UnityEngine;

namespace HotBall
{
    
    internal sealed class UIController : MonoBehaviour
    {
        [SerializeField] private UIScreen mainMenu;
        [SerializeField] private UIScreen restartMenu;
        [SerializeField] private UIScreen playerUI;
        private readonly Dictionary<UIScreenType, UIScreen> _screens = new Dictionary<UIScreenType, UIScreen>();

        private void Awake()
        {
            _screens.Add(UIScreenType.MainMenu, mainMenu);
            _screens.Add(UIScreenType.RestartMenu, restartMenu);
            _screens.Add(UIScreenType.PlayerUI, playerUI);
        }

        public void ShowUI(UIScreenType type)
        {
            _screens[type].gameObject.SetActive(true);
        }
        public void HideUI(UIScreenType type)
        {
            _screens[type].gameObject.SetActive(false);
        }
    }

    internal abstract class UIScreen : MonoBehaviour
    {
    }

    internal enum UIScreenType
    {
        MainMenu,
        RestartMenu,
        PlayerUI
    }
}