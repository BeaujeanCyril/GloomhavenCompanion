﻿namespace GloomhavenCompanion.Application.ViewModels
{
  public class CardViewModel
  {
		public int Id { get; set; }
		public string Value { get; set; }
		public string ImagePath { get; set; }
		public bool NeedShuffle { get; set; } = false;
		public bool IsTemporary { get; set; } = false;
	}
}