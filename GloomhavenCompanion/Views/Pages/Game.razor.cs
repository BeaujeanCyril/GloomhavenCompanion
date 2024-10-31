﻿namespace GloomhavenCompanion.Views.Pages
{
  public partial class Game
  {
    private void NextRound()
    {
      AppState.NextRound();
      ReduceAllElements();
    }

    private void SetElementStrong(int id)
    {
      var element = AppState.Elements.FirstOrDefault(e => e.Id == id);
      if (element != null && (element.State == 0 || element.State == 1))
      {
        element.State = 2; // Fort
      }
    }

    private void UseElement(int id)
    {
      var element = AppState.Elements.FirstOrDefault(e => e.Id == id);
      if (element != null)
      {
        element.State = element.State == 2 ? 0 : (element.State == 1 ? 0 : element.State);
      }
    }

    private void ReduceAllElements()
    {
      foreach (var element in AppState.Elements)
      {
        element.State = element.State == 2 ? 1 : (element.State == 1 ? 0 : element.State);
      }
    }
  }
}