using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DesiredVelocityProvider : MonoBehaviour
    {
        protected Bunny Bunny;

        private void Awake()
        {
            Bunny = GetComponent<Bunny>();
        }

        public abstract Vector2 GetDesiredVelocity();
    }
