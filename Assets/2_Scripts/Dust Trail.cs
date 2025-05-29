using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticleSystem;// 더스트 파티클 시스템
    [SerializeField] AudioClip snowSouond;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            audioSource.PlayOneShot(snowSouond);
            dustParticleSystem.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            dustParticleSystem.Stop();
        }
    }
}
