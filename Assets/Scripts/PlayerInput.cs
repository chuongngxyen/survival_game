using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    public Vector3 GetMovementVectorNormalized()
    {
        Vector3 movementVector = playerInputActions.Player.Move.ReadValue<Vector3>();
        movementVector = movementVector.normalized;
        return movementVector;
    }
    public float GetAttackButton()
    {
        float value = playerInputActions.Player.NormalAttack.ReadValue<float>();
        return value;
    }

    public float GetSettingButton()
    {
        float value = playerInputActions.Player.Setting.ReadValue<float>();
        return value;

    }
}
