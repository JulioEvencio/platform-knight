using Godot;
using System;

namespace PlataformKnight
{
	public partial class Slime : CharacterBody2D
	{
		private const float SPEED = 60.0f;

		private int direction = 1;

		private AnimatedSprite2D sprite;
		private RayCast2D rayCastLeft;
		private RayCast2D rayCastRight;

		public override void _Ready()
		{
			sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
			rayCastRight = GetNode<RayCast2D>("RayCastRight");
		}

		public override void _PhysicsProcess(double delta)
		{
			if (!rayCastLeft.IsColliding())
			{
				sprite.FlipH = false;
				direction = 1;
			}

			if (!rayCastRight.IsColliding())
			{
				sprite.FlipH = true;
				direction = -1;
			}
			
			Vector2 velocity = Velocity;

			velocity.X = SPEED * direction;

			Velocity = velocity;

			MoveAndSlide();
		}
	}
}
