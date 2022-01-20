using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class EnemySpawnBehaviour : PlayableBehaviour
{
    public GameObject Enemy;
    [NonSerialized]
    public Vector2 SpawnPos;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        var enemy = GameObject.Instantiate(Enemy);
        enemy.transform.position = SpawnPos;
    }
}
