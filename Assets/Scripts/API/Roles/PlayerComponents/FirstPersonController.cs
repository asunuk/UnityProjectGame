
using API.Events.EventArgs.Player;
using API.Roles.Interfaces;
using Mirror;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Util;

namespace API.Roles.PlayerComponents
{
	[RequireComponent(typeof(Rigidbody), typeof(CharacterController))]
	public class FirstPersonController : NetworkBehaviour, IFirstPersonController
	{
		protected FpcPlayerRole Player => GetComponent<FpcPlayerRole>();
		protected CharacterController CharacterController => GetComponent<CharacterController>();
		protected Rigidbody Rigidbody => GetComponent<Rigidbody>();
		protected float gravity => Player.Location.gravity;


		[Header("Основные параметры FPC")]

		public bool freezy = false;

		[SerializeField]
		protected Camera _Camera;

		[SerializeField]
		protected GameObject _Head;

		[Header("Клавишы и переменные для управления FPC")]

		public bool sneakOnHold;

		public KeyCode
			forward = KeyCode.W,
			back = KeyCode.S,
			right = KeyCode.D,
			left = KeyCode.A,
			runningKey = KeyCode.LeftShift,
			jumpingKey = KeyCode.Space,
			sneakingKey = KeyCode.LeftAlt;

		[Header("Параметры движением FPC")]

		[SerializeField]
		protected float
			_CameraSensitivityX,
			_CameraSensitivityY;

		[SerializeField]
		protected float
			_WalkingSpeed = 3.5f,
			_RunningSpeed = 5.5f,
			_SneakingSpeed = 1.5f,
			_JumpForce = 4.0f;

		[Header("Элеменеты управления камерой")]

		[SerializeField]
		private float _CameraLimitX = 95.0f;

		//Поля интерфейса IFirstPersonController

		public GameObject Head => _Head;

		public Camera Camera => _Camera;
		public float CameraSenitivityX { get => _CameraSensitivityX; set => _CameraSensitivityX = value; } 
		public float CameraSenitivityY { get => _CameraSensitivityY; set => _CameraSensitivityY = value; }
		public float CameraLimitX { get => _CameraLimitX; set => _CameraLimitX = value; }

		public Vector3 moveDirection => _moveDirection;
		public bool isMoving => Player.gameObject.transform.position != lastPosition;
		public bool isWalking => CurrentStaticSpeed == WalkingSpeed;
		public bool isRunning => Input.GetKey(runningKey);
		public bool isBackMovement => Input.GetKey(back);
		public bool isSneaking => sneakOnHold ? Input.GetKey(sneakingKey) : sneakingOffHold;
		public bool isJumping => Input.GetKey(jumpingKey);
		public float SneakingSpeed { get => _SneakingSpeed; set => _SneakingSpeed = value; } 
		public float WalkingSpeed { get => _WalkingSpeed; set => _WalkingSpeed = value; }
		public float RunningSpeed { get => _RunningSpeed; set => _RunningSpeed = value; }
		public float CurrentSpeed => Vector3.Distance(Player.Body.transform.position, lastPosition);
		public float CurrentStaticSpeed => isRunning && isSneaking ? WalkingSpeed : isRunning ? RunningSpeed : isSneaking ? SneakingSpeed : WalkingSpeed;
		public float JumpForce { get => _JumpForce; set => _JumpForce = value; }

		protected Vector3 _moveDirection = Vector3.zero;
		protected Vector3 lastPosition;
		private Transform defaultCameraTransform;
		private float lastYSpeed;
		private float rotationX;
		private bool sneakingOffHold;

		protected virtual void Start()
		{

			defaultCameraTransform = _Head.transform;

			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		protected virtual void FixedUpdate()
		{
			lastYSpeed = !CharacterController.isGrounded ? lastYSpeed : CurrentStaticSpeed;

			PlayerMoveLogic();
		}

		protected virtual void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape)) freezy = !freezy;
			if (Input.GetKeyDown(sneakingKey)) sneakingOffHold = !sneakingOffHold;


			if (isJumping) Events.Handlers.Player.OnJumping(new JumpingEventArgs(Player));
			if (isMoving) Events.Handlers.Player.OnMove(new MoveEventArgs(Player)); 

			if (!freezy)
			{
				CameraMoveLogic();
				CameraShakeLogic();
				//RunStaminaLogic();
			}
		}

		protected void CameraMoveLogic()
		{
			rotationX += -Input.GetAxis("Mouse Y") * _CameraSensitivityY;
			rotationX = Mathf.Clamp(rotationX, -_CameraLimitX, _CameraLimitX);
			_Camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
			Player.Body.transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _CameraSensitivityX, 0);
		}

		protected void CameraShakeLogic()
		{

		}

		//protected void RunStaminaLogic()
		//{
		//	if (isRunning || isJumping)
		//	{
		//		runStamina.UnreloadU();
		//	} else
		//	{
		//		runStamina.ReloadU();
		//	}

		//	runStaminaProgress.value = runStamina.GetValueInInterest() / 100;
		//}

		protected void PlayerMoveLogic()
		{
			float _lastDirection = _moveDirection.y;
			lastPosition = Player.gameObject.transform.position;

			Vector3 f = GetComponent<FpcPlayerRole>().gameObject.transform.TransformDirection(Vector3.forward) * lastYSpeed;
			Vector3 r = GetComponent<FpcPlayerRole>().gameObject.transform.TransformDirection(Vector3.right) * lastYSpeed;

			Vector3 axis = GetAxis(forward, back, left, right);
			Vector3 _cd = !CharacterController.isGrounded ? moveDirection : (axis.x * r) + (axis.z * f);
			_moveDirection = freezy ? !CharacterController.isGrounded ? _moveDirection : Vector3.zero : !CharacterController.isGrounded ? _moveDirection : _cd;

			_moveDirection.y = (isJumping && CharacterController.isGrounded) && !freezy ? _JumpForce : _lastDirection;
			if (!CharacterController.isGrounded)
			{
				_moveDirection.y -= Player.Location.gravity * Time.fixedDeltaTime;
			}

			CharacterController.Move(moveDirection * Time.fixedDeltaTime);
		}

		protected void PlayerJumpingLogic(Vector3 direction, float lastDirection)
		{
			direction.y = (isJumping && CharacterController.isGrounded) && !freezy ? _JumpForce : lastDirection;
			if (!CharacterController.isGrounded)
			{
				direction.y -= gravity * Time.fixedDeltaTime;
			}
		}

		protected Vector3 GetAxis(KeyCode forward, KeyCode back, KeyCode left, KeyCode right)
		{
			Vector3 rv = Vector3.zero;

			if (Input.GetKey(forward)) rv.z++;
			if (Input.GetKey(back)) rv.z--;
			if (Input.GetKey(right)) rv.x++;
			if (Input.GetKey(left)) rv.x--;

			return rv;
		}
	}
}