using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Debug = UnityEngine.Debug;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class MapAudioController : MonoBehaviour
{
    [SerializeField, EventRef] private string ambienceEvent;
    [SerializeField, EventRef] private string dataCenterEvent;
    [SerializeField, EventRef] private string mainSnapshot;
    [SerializeField, EventRef] private string insideSnapshot;
    [Space]
    [SerializeField, EventRef] private string buzzingEvent;
    [SerializeField] private Transform buzzingPosition;
    [SerializeField, EventRef] private string uiEvent;
    [SerializeField] private Transform uiPosition;
    [Space]
    [SerializeField, EventRef] private string doorsEvent;
    [SerializeField] private Transform doors;

    private EventInstance _ambienceEventInstance;
    private EventInstance _dataCenterEventInstance;
    
    private EventInstance _buzzingEventInstance;
    private EventInstance _uiEventInstance;
    
    private EventInstance _mainSnapshotInstance;
    private EventInstance _insideSnapshotInstance;

    private void Start()
    {
        _ambienceEventInstance = RuntimeManager.CreateInstance(ambienceEvent);
        _dataCenterEventInstance = RuntimeManager.CreateInstance(dataCenterEvent);

        _buzzingEventInstance = RuntimeManager.CreateInstance(buzzingEvent);
        _buzzingEventInstance.set3DAttributes(buzzingPosition.position.To3DAttributes());
        
        _uiEventInstance = RuntimeManager.CreateInstance(uiEvent);
        _uiEventInstance.set3DAttributes(uiPosition.position.To3DAttributes());
        
        _mainSnapshotInstance = RuntimeManager.CreateInstance(mainSnapshot);
        _insideSnapshotInstance = RuntimeManager.CreateInstance(insideSnapshot);

        _mainSnapshotInstance.start();
        _ambienceEventInstance.start();

    }

    public void PlayDoorsSound()
    {
        RuntimeManager.PlayOneShot(doorsEvent, doors.position);
    }

    public void PlayInsideSnapshot()
    {
        Debug.LogError("Inside snapshot start!");
        _insideSnapshotInstance.start();
        _dataCenterEventInstance.start();
    }
    
    public void StopInsideSnapshot()
    {
        Debug.LogError("Inside snapshot stopped!");
        _insideSnapshotInstance.stop(STOP_MODE.ALLOWFADEOUT);
        _dataCenterEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
    }

    public void PlayBuzzingEvent()
    {
        Debug.LogError("Buzzing started");
        _buzzingEventInstance.start();
    }

    public void StopBuzzingEvent()
    {
        Debug.LogError("Buzzing stopped");
        _buzzingEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
    }
    
    public void PlayUIEvent()
    {
        Debug.LogError("UI started");
        _uiEventInstance.start();
    }

    public void StopUIEvent()
    {
        Debug.LogError("UI stopped");
        _uiEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
