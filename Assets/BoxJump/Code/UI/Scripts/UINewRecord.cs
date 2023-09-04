using BoxJump.Code.GameLogic;
using TMPro;
using UnityEngine;

public class UINewRecord : MonoBehaviour
{

    [SerializeField] private TMP_Text _text;
    
    void Awake()
    {
        _text.text = $"New Record <br>{GameManager.Score}";
    }
}
