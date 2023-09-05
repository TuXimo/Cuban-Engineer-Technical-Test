using BoxJump.Code.GameLogic;
using TMPro;
using UnityEngine;

namespace BoxJump.Code.UI.Scripts
{
    public class UISetName : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputFieldName;
        private PlayerData _playerData;


        private void Start()
        {
            SetupData();
            
            inputFieldName.onValueChanged.AddListener(arg0 => NameDataSave());
        }

        private void SetupData()
        {
            _playerData = JsonManager.LoadFromJson<PlayerData>("PlayerData");
            if (_playerData.Name != "")
            {
                inputFieldName.text = _playerData.Name;
            }
        }

        private void NameDataSave()
        {
            _playerData.Name = inputFieldName.text;
            JsonManager.SaveToJson(_playerData, "PlayerData");
        }
    }
}