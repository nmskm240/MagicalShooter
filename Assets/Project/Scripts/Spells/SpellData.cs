using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Shooting.Bullets;
using Shooting.Motions;

namespace Shooting.Spells
{
    [CreateAssetMenu(fileName = "SpellData", menuName = "Shooting/SpellData", order = 0)]
    public class SpellData : ScriptableObject
    {
        [System.Serializable]
        private class SpellBulletInfo
        {
            [SerializeField]
            private BulletDataSet _dataSet;
            [SerializeField]
            private List<MotionData> _motions;

            public BulletDataSet DataSet { get { return _dataSet; } }
            public IEnumerable<MotionData> Motions { get { return _motions; } }
        }

        [SerializeField]
        private string _name;
        [SerializeField, Multiline]
        private string _detail;
        [SerializeField]
        private List<SpellBulletInfo> _bulletInfos;

        public string Name { get { return _name; } }
        public string Detail { get { return _detail; } }
        public IEnumerable<GameObject> Bullets
        {
            get
            {
                return _bulletInfos.Select(info =>
                {
                    var dataSet = Instantiate(info.DataSet);
                    dataSet.Model.Motions = info.Motions;
                    return dataSet.Prefab;
                });
            }
        }
    }
}