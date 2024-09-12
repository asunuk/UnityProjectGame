

using UnityEngine;

namespace Game.Roles.Interfaces
{
	public interface IMovement : IJumping
	{
		/// <summary>
		/// Вектор напрвление движения объекта.
		/// </summary>
		public Vector3 moveDirection { get; }

		/// <summary>
		/// Скорость объекта при медленном передвижение
		/// </summary>
		public float SneakingSpeed { get; set; }

		/// <summary>
		/// Скорость объекта при обычном передвижение
		/// </summary>
		public float WalkingSpeed { get; set; }
		/// <summary>
		/// Скорость объекта при быстром передвижение (беге)
		/// </summary>
		public float RunningSpeed { get; set; }

		/// <summary>
		/// Возвращает текущую скорость объекта, с учётом внешних факторов
		/// </summary>
		public float CurrentSpeed { get; }

		/// <summary>
		/// Возвращает текущую скорость объекта, без учёта внешних факторов
		/// </summary>
		public float CurrentStaticSpeed { get; }

		public bool isMoving { get; }
		public bool isRunning { get; }
		public bool isWalking { get; }
		public bool isSneaking { get; }
		public bool isJumping { get; }
	}
}
