using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HotBall
{
    public sealed class GameController : MonoBehaviour
    {
        private InteractiveObject[] _interactiveObjects;
        [SerializeField] private AudioSource soundSource;
        [SerializeField] private TMP_Text redKeyText;
        private readonly List<Player> _players = new List<Player>();
        [SerializeField] private CameraController cameraController; 
        
        internal static Inventory Inventory { get; private set; }
        private const int NEED_RED_KEY = 3;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            _players.AddRange(FindObjectsOfType<Player>());
            Inventory = new Inventory();
            Inventory.OnUpdate += RefreshUI;
        }

        private void Start()
        {
            InitInteractiveObjects();
            RefreshUI();
        }

        private void InitInteractiveObjects()
        {
            foreach (var interactiveObject in _interactiveObjects)
            {
                if (interactiveObject is INeedAudioSource obj) obj.SetAudioSource(soundSource);
            }
        }

        private void RefreshUI()
        {
            redKeyText.text = $"{Inventory.GetItemCount(ItemType.RED_KEY)}/{NEED_RED_KEY}";
        }

        private void Update()
        {
            for (var i = 0 ; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];
                if (interactiveObject == null) continue;
                
                if (interactiveObject is IAnimate obj) obj.Animate();
            }
            foreach (var player in _players)
            {
                player.UpdateTick(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            cameraController.FixedTick();
            foreach (var player in _players)
            {
                player.FixedTick();
            }
        }
    }
}