using UnityEngine;

namespace UI
{
	public class UIController : MonoBehaviour
	{
		[SerializeField] private UIMap _uiMap;
		[SerializeField] private UIMissionManager _uiMission;
		[SerializeField] private UIPlayerPanel _panel;
		
		
		public void Initialize(PlayerProgress progress)
		{
			_uiMap.GenerateMap(progress.AvailableMissions);
			_panel.ViewAvailableUnits(progress.AvailableUnits);
			_uiMission.GetViewMissionList();
		}
	}
}