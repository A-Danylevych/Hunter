using System.Collections;
using UnityEngine;

namespace Spawn
{
    public class AnimalSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnConfigSO config;
        void Start()
        {
           StartCoroutine(SpawnRabbits());
           StartCoroutine(SpawnMoose());
           StartCoroutine(SpawnWolfs());
        }

        private IEnumerator SpawnWolfs()
        {
            for (int i = 0; i < config.GetWolfCount(); i++)
            {
                Instantiate(config.GetWolfPrefab(),
                    config.GetRandomPosition(),
                    Quaternion.identity, transform);
                yield return new WaitForSeconds(config.GetSpawnTime());
            }
        }

        private IEnumerator SpawnMoose()
        {
            for (int i = 0; i < config.GetMooseGroupCount(); i++)
            {
                var position = config.GetRandomPosition();
                for (int j = 0; j < config.GetMooseGroupSize(); j++)
                {
                    Instantiate(config.GetMoosePrefab(),
                        position,
                        Quaternion.identity, transform);
                    yield return new WaitForSeconds(config.GetSpawnTime());
                }
            }
        }

        private IEnumerator SpawnRabbits()
        {
            for (int i = 0; i < config.GetRabbitCount(); i++)
            {
                Instantiate(config.GetRabbitPrefab(),
                    config.GetRandomPosition(),
                    Quaternion.identity, transform);
                yield return new WaitForSeconds(config.GetSpawnTime());
            }
        }
    }
}
