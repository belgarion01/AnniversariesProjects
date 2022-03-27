using System.Collections;
using System.Collections.Generic;
using Shapes;
using UnityEngine;
using UnityEngine.UI;

public class DinerTimerVisual : MonoBehaviour
{
    [SerializeField] private Disc _successAngleDisc;
    [SerializeField] private Transform _arrowRoot;
    [SerializeField] private DinerTimerHandler _dinerTimerHandler;

    void Awake()
    {
        _dinerTimerHandler.OnTimerValueChanged.AddListener(UpdateVisual);
    }

    void Start()
    {
        if (_dinerTimerHandler.CurrentDinerTimer != null)
        {
            UpdateVisual(_dinerTimerHandler.CurrentDinerTimer);
        }
    }

    public void UpdateVisual(DinerTimer dinerTimer)
    {
        _successAngleDisc.AngRadiansStart = dinerTimer.SuccessAngle.x * Mathf.Deg2Rad;
        _successAngleDisc.AngRadiansEnd = dinerTimer.SuccessAngle.y * Mathf.Deg2Rad;

        Vector3 r = _arrowRoot.rotation.eulerAngles;
        _arrowRoot.rotation = Quaternion.Euler(r.x, r.y, dinerTimer.ArrowAngle - 90f);
    }
}
