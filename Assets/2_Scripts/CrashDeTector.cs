using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 1f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSound;

    private AudioSource audioSource;
    private PlayController playerController;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = GetComponent<PlayController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            crashEffect.Play();
            audioSource.PlayOneShot(crashSound);
            playerController.GameOVer();
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

