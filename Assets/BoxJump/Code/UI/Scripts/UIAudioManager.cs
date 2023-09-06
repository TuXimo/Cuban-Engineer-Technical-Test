using BoxJump.Code.GameLogic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace BoxJump.Code.UI.Scripts
{
    public class UIAudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider[] audioSliders;

        private AudioData _audioData = new();

        private void Awake()
        {
            _audioData = JsonManager.LoadFromJson<AudioData>("AudioData");

            foreach (var audioSlider in audioSliders)
                audioSlider.onValueChanged.AddListener(arg0 => SaveAudioDataJson());

            audioSliders[0].onValueChanged.AddListener(SetMasterVolume);
            audioSliders[1].onValueChanged.AddListener(SetMusicVolume);
            audioSliders[2].onValueChanged.AddListener(SetSfxVolume);


            if (_audioData != null)
            {
                audioSliders[0].value = _audioData.MasterVolume == 0 ? 1 : _audioData.MasterVolume;
                audioSliders[1].value = _audioData.MusicVolume == 0 ? 1 : _audioData.MusicVolume;
                audioSliders[2].value = _audioData.SfxVolume == 0 ? 1 : _audioData.SfxVolume;
            }
        }

        private void SetMasterVolume(float volume)
        {
            var logVolume = Mathf.Log10(volume) * 20;

            audioMixer.SetFloat("MasterVolume", logVolume);
            _audioData.MasterVolume = volume;
        }

        private void SetSfxVolume(float volume)
        {
            var logVolume = Mathf.Log10(volume) * 20;

            audioMixer.SetFloat("SFXVolume", logVolume);
            _audioData.SfxVolume = volume;
        }

        private void SetMusicVolume(float volume)
        {
            var logVolume = Mathf.Log10(volume) * 20;

            audioMixer.SetFloat("MusicVolume", logVolume);
            _audioData.MusicVolume = volume;
        }

        public void SaveAudioDataJson()
        {
            JsonManager.SaveToJson(_audioData, "AudioData");
        }
    }
}