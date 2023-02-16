using UnityEngine;

public class Seed : HighScore
{
    [SerializeField] private AudioClip _triggerSound;
    [SerializeField] private HighScore _highScore;

    private GameSession _session;
    private AudioSource _audioSource;
    public HighScore Score => _highScore;

    private void Start()
    {
        _session = FindObjectOfType<GameSession>().GetComponent<GameSession>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void AddSeed()
    {
        _audioSource.PlayOneShot(_triggerSound);
        _session.Data.Seeds++;
        _session.Data.Enemies++;
        EndGame(_session.Data.Seeds);
    }

    public void EndGame(float score)
    {
        // Update the high score
        _highScore.UpdateHighScore(score);
    }
}
