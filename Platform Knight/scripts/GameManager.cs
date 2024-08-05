using Godot;
using System;

namespace PlataformKnight
{
	public partial class GameManager : Node
	{
		private int score = 0;

		private Label scoreLabel;

		public override void _Ready()
		{
			scoreLabel = GetNode<Label>("Score");
			UpdateScoreLabel();
		}

		public void AddScore(int score)
		{
			this.score += score;
			UpdateScoreLabel();
		}

		private void UpdateScoreLabel()
		{
			scoreLabel.Text = "You collected " + score + " coins";
		}
	}
}
