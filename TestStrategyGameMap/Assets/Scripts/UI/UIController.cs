using UnityEngine;

namespace UI
{
	public class UIController : MonoBehaviour
	{
		[SerializeField] private UIMap _uiMap;
		[SerializeField] private UIPlayerPanel _panel;
		[SerializeField] private UIMissionManager _uiMission;
		
		public void Initialize(PlayerProgress progress)
		{
			_uiMap.GenerateMap(progress.AvailableMissions);
			_panel.ViewAvailableUnits(progress.AvailableUnits);
			_uiMission.GetViewMissionList();
		}
	}
}