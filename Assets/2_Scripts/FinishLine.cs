using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float delayBeforLoading = 2f;
    [SerializeField] private ParticleSystem finishEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            finishEffect.Play();
            Invoke(nameof(LoadSceneMode), delayBeforLoading);
        }
    }

    private void LoadSceneMode()
    {
        SceneManager.LoadScene(0); // Assuming scene index 1 is the next level
    }

}
