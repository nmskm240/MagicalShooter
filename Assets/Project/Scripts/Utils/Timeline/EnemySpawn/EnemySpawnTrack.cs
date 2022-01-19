using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(1f, 0.27f, 0f)]
[TrackClipType(typeof(EnemySpawnClip))]
public class EnemySpawnTrack : TrackAsset
{
    [SerializeField]
    private Vector2 _pos;
    
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var clips = GetClips();
        foreach(var clip in clips)
        {
            var spawnClip = clip.asset as EnemySpawnClip;
            spawnClip.template.SpawnPos = _pos;
        }
        return ScriptPlayable<EnemySpawnMixerBehaviour>.Create (graph, inputCount);
    }

    protected override void OnCreateClip (TimelineClip clip)
    {
        clip.duration = 1f;
    }
}
