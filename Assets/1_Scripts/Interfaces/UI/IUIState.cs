using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIState
{
    void EnterState(UIStateManager uiManager);
    void UpdateState(UIStateManager uiManager);
    void ExitState(UIStateManager uiManager);
}
