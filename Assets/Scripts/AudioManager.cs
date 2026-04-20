using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Scene Names")]
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private string gameSceneName = "Jogo";

    [Header("Music")]
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;

    [Header("SFX")]
    [SerializeField] private AudioClip victorySfx;
    [SerializeField] private AudioClip gameOverSfx;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (musicSource == null || sfxSource == null)
        {
            AudioSource[] sources = GetComponents<AudioSource>();

            if (sources.Length >= 1 && musicSource == null)
                musicSource = sources[0];

            if (sources.Length >= 2 && sfxSource == null)
                sfxSource = sources[1];
        }

        if (musicSource != null)
        {
            musicSource.playOnAwake = false;
            musicSource.loop = true;
            musicSource.spatialBlend = 0f;
        }

        if (sfxSource != null)
        {
            sfxSource.playOnAwake = false;
            sfxSource.loop = false;
            sfxSource.spatialBlend = 0f;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        PlayMusicForScene(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    private void PlayMusicForScene(string sceneName)
    {
        if (sceneName == mainMenuSceneName)
        {
            PlayMenuMusic();
        }
        else if (sceneName == gameSceneName)
        {
            PlayGameMusic();
        }
    }

    public void PlayMenuMusic()
    {
        if (musicSource == null || menuMusic == null) return;

        if (musicSource.clip == menuMusic && musicSource.isPlaying) return;

        musicSource.Stop();
        musicSource.clip = menuMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayGameMusic()
    {
        if (musicSource == null || gameMusic == null) return;

        if (musicSource.clip == gameMusic && musicSource.isPlaying) return;

        musicSource.Stop();
        musicSource.clip = gameMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayVictorySound()
    {
        if (sfxSource == null || victorySfx == null) return;

        sfxSource.PlayOneShot(victorySfx);
    }

    public void PlayGameOverSound()
    {
        if (sfxSource == null || gameOverSfx == null) return;

        sfxSource.PlayOneShot(gameOverSfx);
    }
}