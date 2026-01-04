using UnityEngine;

public class SwitchBGMOnce : MonoBehaviour
{
    public AudioSource defaultBGM;
    public AudioSource newBGM;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        // Teleport script still runs normally

        if (!triggered)
        {
            if (defaultBGM != null && defaultBGM.isPlaying)
                defaultBGM.Stop();

            if (newBGM != null)
                newBGM.Play();

            triggered = true;
        }
    }
}
