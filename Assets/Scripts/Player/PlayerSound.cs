using UnityEngine;
[RequireComponent(typeof(AudioSource), typeof(ISoundPlayer))]
public class PlayerSound : MonoBehaviour, ISoundPlayer
{
    [SerializeField] private AudioClip playerDieSound;
    [SerializeField] private AudioClip playerLandSound;
    [SerializeField] private AudioClip playerJumpSound;

    private AudioSource _playerAudioSource;

    private void Start()
    {
        _playerAudioSource = GetComponent<AudioSource>();
    }

    public void PlayDieSound()
    {
        _playerAudioSource.PlayOneShot(playerDieSound);
    }

    public void PlayLandSound()
    {
        _playerAudioSource.PlayOneShot(playerLandSound);
    }

    public void PlayJumpSound()
    {
        _playerAudioSource.PlayOneShot(playerJumpSound);
    }
}