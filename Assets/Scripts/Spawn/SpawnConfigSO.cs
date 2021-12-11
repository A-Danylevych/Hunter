using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    [CreateAssetMenu(menuName = "Spawn Config", fileName = "New Spawn Config")]
    public class SpawnConfigSO : ScriptableObject
    {
        [SerializeField] private BoxCollider2D ground;
        [SerializeField] private int rabbitCount = 5;
        [SerializeField] private int mooseGroupCount = 5;
        [SerializeField] private int mooseGroupSize = 5;
        [SerializeField] private int wolfCount = 5;
        [SerializeField] private float timeBetweenSpawns = 1f;
        [SerializeField] private GameObject rabbitPrefab;
        [SerializeField] private GameObject moosePrefab;
        [SerializeField] private GameObject wolfPrefab;
        
        public int GetRabbitCount()
        {
            return rabbitCount;
        }
        public int GetMooseGroupCount()
        {
            return mooseGroupCount;
        }
        public int GetMooseGroupSize()
        {
            return mooseGroupSize;
        }
        public int GetWolfCount()
        {
            return wolfCount;
        }

        public GameObject GetRabbitPrefab()
        {
            return rabbitPrefab;
        }
        public GameObject GetMoosePrefab()
        {
            return moosePrefab;
        }
        public GameObject GetWolfPrefab()
        {
            return wolfPrefab;
        }
        
        public Vector2 GetCenter()
        {
            return ground.offset;
        }

        public Vector2 GetSize()
        {
            return ground.size;
        }

        public Vector2 GetRandomPosition()
        {
            var randomPosition = new Vector2(Random.Range(-ground.size.x / 2, ground.size.x / 2), 
                Random.Range(-ground.size.y / 2, ground.size.y / 2));
 
            return ground.offset + randomPosition;
        }

        public float GetSpawnTime()
        {
            return timeBetweenSpawns;
        }
    }
}
