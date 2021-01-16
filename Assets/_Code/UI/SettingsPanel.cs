using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : UiPanel
{

    [SerializeField] private string masterVCA;
    [SerializeField] private string musicVCA;
    [SerializeField] private string sfxVCA;
    
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider effectsVolumeSlider;

    private VCA _masterVCAInstance;
    private VCA _musicCAInstance;
    private VCA _sfxVCAInstance;

    protected override void OnInitialise() { }

    protected override void OnOpen()
    {
        _masterVCAInstance = RuntimeManager.GetVCA(masterVCA);
        _musicCAInstance = RuntimeManager.GetVCA(musicVCA);
        _sfxVCAInstance = RuntimeManager.GetVCA(sfxVCA);

        _masterVCAInstance.getVolume(out var masterVolume);
        masterVolumeSlider.SetValueWithoutNotify(masterVolume);
        
        _musicCAInstance.getVolume(out var musicVolume);
        musicVolumeSlider.SetValueWithoutNotify(musicVolume);
        
        _sfxVCAInstance.getVolume(out var sfxVolume);
        effectsVolumeSlider.SetValueWithoutNotify(sfxVolume);
        
        masterVolumeSlider.onValueChanged.AddListener((x) => HandleVolumeUpdate(x, _masterVCAInstance));
        musicVolumeSlider.onValueChanged.AddListener((x) => HandleVolumeUpdate(x, _musicCAInstance));
        effectsVolumeSlider.onValueChanged.AddListener((x) => HandleVolumeUpdate(x, _sfxVCAInstance));
    }

    protected override void OnClose()
    {
        _masterVCAInstance.clearHandle();
        _musicCAInstance.clearHandle();
        _sfxVCAInstance.clearHandle();

        masterVolumeSlider.onValueChanged.RemoveAllListeners();
        musicVolumeSlider.onValueChanged.RemoveAllListeners();
        effectsVolumeSlider.onValueChanged.RemoveAllListeners();
    }

    private void HandleVolumeUpdate(float volume, VCA vcaInstance)
    {
        vcaInstance.setVolume(volume);
    }
}