using Godot;
using System;

namespace PlataformKnight.Scripts
{
	public partial class KillZone : Area2D
	{
		private Timer _timer;

		public override void _Ready()
		{
			_timer = GetNode<Timer>("Timer");
		}

		private void OnBodyEntered(Player player)
		{
			Engine.TimeScale = 0.5f;
			player.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
			_timer.Start();
		}

		private void OnTimerTimeout()
		{
			Engine.TimeScale = 1.0f;
			GetTree().ReloadCurrentScene();
		}
	}
}
