using UnityEngine;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Instance { get; private set; }

        [SerializeField] private int totalEnemies = 5;
        [SerializeField] private AudioClip gateOpenSfx;

        private AudioSource audioSource;
        private int enemiesRemaining;
        private bool doorsOpened;

        private void Awake()
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            enemiesRemaining = totalEnemies;
            Debug.Log("Orcs restantes: " + enemiesRemaining);
        }

        public static void EnemyDied()
        {
            if (Instance == null) return;

            Instance.enemiesRemaining--;
            Debug.Log("Orcs restantes: " + Instance.enemiesRemaining);

            if (Instance.enemiesRemaining <= 0 && !Instance.doorsOpened)
            {
                Instance.OpenDoors();
            }
        }

        private void OpenDoors()
        {
            doorsOpened = true;

            if (gateOpenSfx != null && audioSource != null)
                audioSource.PlayOneShot(gateOpenSfx);

            GameObject[] portas = GameObject.FindGameObjectsWithTag("Portao");

            foreach (GameObject porta in portas)
            {
                Destroy(porta);
            }
        }
    }
}