using Runner.Controllers;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.Views
{
    public class RoadView : MonoBehaviour
    {
        [SerializeField]
        private RoadSectionView _floorPrefab;
        
        private RoadController _roadController;
        private List<RoadSectionView> _sections = new List<RoadSectionView>();

        [Inject]
        public void Init(RoadController roadController)
        {
            _roadController = roadController;
            _roadController.OnRoadUpdate += UpdateRoad;

            UpdateRoad();
        }

        void UpdateRoad()
        {
            var sectionIndex = 0;
            foreach (var sectionInfo in _roadController.Sections) 
            {
                if (_sections.Count <= sectionIndex)
                {
                    var instance = Instantiate(_floorPrefab, transform);                    
                    _sections.Add(instance);
                }

                _sections[sectionIndex].transform.localPosition = new Vector3(0f, 0f, sectionInfo.Position);
                _sections[sectionIndex++].Refresh(sectionInfo.Obstacle);
            }
        }
    }
}

