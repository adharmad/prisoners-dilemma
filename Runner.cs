using System;

namespace prisonersdilemma {
    class Runner {
        static void Main(string[] args) {
            PrisonersDilemma pd = new PrisonersDilemma(100);
            pd.InitializePlayers();
            pd.PlayGames();
            pd.OutputResults();
        }
    }
}
