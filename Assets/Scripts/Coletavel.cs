using UnityEngine;

    public class Coletavel : MonoBehaviour
    {
        private Animator animator;
        void Start()
        {
            
        }

        void Update()
        {
            animator.SetFloat("Speed", 0);
        }
    }
