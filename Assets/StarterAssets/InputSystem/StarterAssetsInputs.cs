using UnityEngine;
using UnityEngine.Animations;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool CameraMoveUp;
        public bool CameraMoveDown;
        public bool jump;
        public bool sitForCrouch;
        public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM

		public void OnSitForCrouch(InputValue value)
		{
			SitForCrouchInput(value.isPressed);
		}

		public void OnCameraMoveUp(InputValue value)
		{
			CameraMoveUpInput(value.isPressed);
        }

        public void OnCameraMoveDown(InputValue value)
        {
            CameraMoveDownInput(value.isPressed);

        }

        public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
#endif
		public void SitForCrouchInput(bool newSitState)
		{
			sitForCrouch = newSitState;
		}


        public void CameraMoveUpInput(bool newUpState)
		{
			CameraMoveUp = newUpState;

        }

        public void CameraMoveDownInput(bool newDownState)
        {
            CameraMoveDown = newDownState;

        }

        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}