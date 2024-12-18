using UnityEngine;

public class DataStorage : MonoBehaviour
{
    //Cross scene data management
    
    public FullScreenMode FullScreenMode;
    public Resolution Resolution;
    public float Volume = 50f;
    public bool PeacefulMusic = true;

    public AudioClip NeonGrave;
    public AudioClip NeonGraveAcoustic;
    public AudioClip WishYouTheBest;
    public AudioClip MyImmortal;
    public static DataStorage Settings { get; set; }

    void Awake()
    {
        if (Settings == null)
        {
            DontDestroyOnLoad(gameObject);
            Settings = this;
        }
    }
    void Start()
    {
        FullScreenMode = Screen.fullScreenMode;
        Resolution = Screen.currentResolution;
    }
}
