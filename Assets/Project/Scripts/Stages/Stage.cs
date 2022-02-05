using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MagicalShooter.Stages
{
    public class Stage : Presenter<TimelineAsset, PlayableDirector>
    {
        [SerializeField]
        private TimelineAsset _pattan;

        private void Start()
        {
            _view.playableAsset = _pattan;
            _view.Play();
        }
    }
}