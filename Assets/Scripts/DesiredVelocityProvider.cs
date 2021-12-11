using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DesiredVelocityProvider : MonoBehaviour
    {
        [SerializeField, Range(0,3)]
        private float weight = 1f;
        
        public float Weight => weight;
        
        protected Bunny Bunny;

        private void Awake()
        {
            Bunny = GetComponent<Bunny>();
        }

        public abstract Vector3 GetDesiredVelocity();
    }
