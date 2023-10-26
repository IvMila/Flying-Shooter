using UnityEngine;

public class TaskGame : MonoBehaviour
{
    private UIController _uIController;
    private void Start()
    {
        _uIController = UIController.UIControllerInstance;
        GlobalEventManager.OnEnemyKillled += Check;
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnEnemyKillled -= Check;
    }

    public void Check()
    {
        if (_uIController.Amoutn == СonstantsScript.TASK_AMOUNT_KILLED_ENEMY)
        {
            GlobalEventManager.SendWin();
        }
    }
}
