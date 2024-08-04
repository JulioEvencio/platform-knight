using Godot;
using System;

namespace PlataformKnight
{
	public partial class KillZone : Area2D
	{
		private Timer timer;

		public override void _Ready()
		{
			timer = GetNode<Timer>("Timer");
		}
		
		private void OnBodyEntered(Player player)
		{
			Engine.TimeScale = 0.5f;
			player.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
			timer.Start();
		}

		private void OnTimerTimeout()
		{
			Engine.TimeScale = 1.0f;
			GetTree().ReloadCurrentScene();
		}
	}
}
