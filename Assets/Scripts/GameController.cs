using TMPro;
using UnityEngine;

namespace HotBall
{
    public class GameController : MonoBehaviour
    {
        private InteractiveObject[] _interactiveObjects;
        [SerializeField] private AudioSource soundSource;
        [SerializeField] private TMP_Text redKeyText;
        internal static Inventory Inventory { get; private set; }
        private const int NEED_RED_KEY = 3;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            Inventory = new Inventory();
            Inventory.OnUpdate += RefreshUI;
        }

        private void RefreshUI()
        {
            redKeyText.text = $"{Inventory.GetItemCount(ItemType.RED_KEY)}/{NEED_RED_KEY}";
        }

        private void Start()
        {
            foreach (var interactiveObject in _interactiveObjects)
            {
                if (interactiveObject is INeedAudioSource obj)
                    obj.SetAudioSource(soundSource);
            }
            RefreshUI();
        }

        private void Update()
        {
            for (var i =  0 ; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];
                if (interactiveObject == null) continue;
                
                if (interactiveObject is IAnimate obj) obj.Animate();
            }
        }
    }
}