using System.Globalization;
using BoxJump.Code.GameLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BoxJump.Code.UI.Scripts
{
    public class UISetColor : MonoBehaviour
    {
        [SerializeField] private Image imageColor;
        [SerializeField] private TMP_InputField inputTextColor;
        private Color _playerColor;
        private PlayerData _playerData = new PlayerData();


        private void Awake()
        {
            LoadAndSetPlayerData();
            inputTextColor.onValueChanged.AddListener(ChangeColor);
        }

        private void ChangeColor(string hexValue)
        {
            hexValue = hexValue.Replace("#", "");

            if (hexValue.Length == 6)
            {
                _playerColor = HexToColorCode(inputTextColor.text);
                imageColor.color = _playerColor;
                _playerData.Color = _playerColor;
                JsonManager.SaveToJson(_playerData, "PlayerData");
            }
        }

        private Color HexToColorCode(string hex)
        {
            hex = hex.Replace("#", "");
            var r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
            var g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
            var b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);

            return new Color32(r, g, b, 255);
        }

        private void LoadAndSetPlayerData()
        {
            _playerData = JsonManager.LoadFromJson<PlayerData>("PlayerData");

            if (_playerData.Color == new Color(0, 0, 0, 0))
            {
                _playerData.Color = imageColor.color;
            }
            
            imageColor.color = _playerData.Color;
            
            JsonManager.SaveToJson(_playerData, "PlayerData");
        }
    }
}