using Godot;
using System;

namespace PlataformKnight.Scripts
{
	public partial class Slime : CharacterBody2D
	{
		private const float Speed = 60.0f;

		private int _direction = 1;

		private AnimatedSprite2D _sprite;
		private RayCast2D _rayCastLeft;
		private RayCast2D _rayCastRight;

		public override void _Ready()
		{
			_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			_rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
			_rayCastRight = GetNode<RayCast2D>("RayCastRight");
		}

		public override void _PhysicsProcess(double delta)
		{
			if (!_rayCastLeft.IsColliding())
			{
				_sprite.FlipH = false;
				_direction = 1;
			}

			if (!_rayCastRight.IsColliding())
			{
				_sprite.FlipH = true;
				_direction = -1;
			}
			
			Vector2 velocity = Velocity;

			velocity.X = Speed * _direction;

			Velocity = velocity;

			MoveAndSlide();
		}
	}
}
