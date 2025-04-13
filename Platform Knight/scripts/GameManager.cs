using Godot;
using System;

namespace PlataformKnight.Scripts
{
	public partial class GameManager : Node
	{
		private int _score = 0;

		private Label _scoreLabel;

		public override void _Ready()
		{
			_scoreLabel = GetNode<Label>("Score");

			UpdateScoreLabel();
		}

		public void AddScore(int score)
		{
			_score += score;
			
			UpdateScoreLabel();
		}

		private void UpdateScoreLabel()
		{
			_scoreLabel.Text = "You collected " + _score + " coins";
		}
	}
}
