using Godot;
using System;

public partial class KillZone : Area2D
{
	private Timer timer;

	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
	}
	
	private void _on_body_entered(Player player)
	{
		timer.Start();
	}

	private void _on_timer_timeout()
	{
		GetTree().ReloadCurrentScene();
	}
}
