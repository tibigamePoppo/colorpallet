using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SeManager : MonoBehaviour
{
    public static SeManager Instance { get; private set; }
    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> seLists;

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("�C���X�^���X����");
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("�C���X�^���X����Ă��邩�������");
            Destroy(gameObject);
        }
    }

    public void ShotSe(SeType type)
    {
        AudioClip clip = null;
        clip = seLists.FirstOrDefault(se => se.name.Equals(type.ToString()));

        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
    //����炷�ꍇ    SeManager.Instance.ShotSe(SeType.laser);�Ə���
}
