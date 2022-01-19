using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class EnemySpawnClip : PlayableAsset, ITimelineClipAsset
{
    public EnemySpawnBehaviour template = new EnemySpawnBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<EnemySpawnBehaviour>.Create (graph, template);
        EnemySpawnBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
