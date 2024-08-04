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
			timer.Start();
		}

		private void OnTimerTimeout()
		{
			GetTree().ReloadCurrentScene();
		}
	}
}
