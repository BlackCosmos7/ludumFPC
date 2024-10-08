using System.Collections;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip[] audioClips; // ������ ��� �������� ������
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(PlaySounds());
    }

    private IEnumerator PlaySounds()
    {
        int index = 0;

        while (true)
        {
            // ����������� ������� ����
            audioSource.clip = audioClips[index];
            audioSource.Play();

            // ����, ���� ���� ����������
            yield return new WaitForSeconds(audioClips[index].length);

            // ���� ��������� ����� �� 20 �� 30 ������
            float waitTime = Random.Range(15f, 20f);
            yield return new WaitForSeconds(waitTime);

            // ��������� � ���������� �����
            index = (index + 1) % audioClips.Length;
        }
    }
}
