using System;
using System.Collections.Generic;
using System.Collections;

namespace prisonersdilemma {
    class PrisonersDilemma {
        public readonly string PLAYER_NAMESPACE = "prisonersdilemma.players";
        private List<Player> players;
        private int numGames = 1;
        private Hashtable scores;
        private string[] playerNames = {
            "Altruist",
            "Evil",
            "TitForTat",
            "Vindictive",
            "RandomPlayer"
        };

        public PrisonersDilemma(){
            players = new List<Player>();
            scores = new Hashtable();
        }

        public PrisonersDilemma(int numOfGames) : this() {
            numGames = numOfGames;
        }

        public void InitializePlayers() {
            for (int i=0 ; i<playerNames.Length ; i++) {
                string playerName = playerNames[i];
                string playerClassName = PLAYER_NAMESPACE + "." + playerName;
                Type type = Type.GetType(playerClassName);
                Player player = (Player)Activator.CreateInstance(type);
                player.Initialize();
                players.Add(player);
            }
        }

        public void PlayGames() {

            for (int i=0 ; i<players.Count-1 ; i++) {
                for (int j=i+1 ; j<players.Count ; j++) {
                    Player player1 = players[i];
                    Player player2 = players[j];

                    PlayGamesBetweenTwoPlayers(player1, player2);

                }
            }
        }

        private void PlayGamesBetweenTwoPlayers(Player player1, Player player2) {
            for (int i=0 ; i<numGames ; i++) {
                PlaySingleGame(player1, player2);
                //Console.WriteLine("Playing game between " + player1.GetName() + " and " + player2.GetName());
            }
        }


        private void PlaySingleGame(Player player1, Player player2) {
            Match match = new Match(player1, player2);
            match.PlayMatch();
            RecordResult(match);
            player1.Notify(match);
            player2.Notify(match);
        }

        private void RecordResult(Match match) {
            Player player1 = match.FirstPlayer;
            Player player2 = match.SecondPlayer;

            if (!scores.ContainsKey(player1.GetName())) {
                scores[player1.GetName()] = match.GetPoints(player1.GetName());
            } else {
                scores[player1.GetName()] = (int)scores[player1.GetName()] + match.GetPoints(player1.GetName());
            } 

            if (!scores.ContainsKey(player2.GetName())) {
                scores[player2.GetName()] = match.GetPoints(player2.GetName());
            } else {
                scores[player2.GetName()] = (int)scores[player2.GetName()] + match.GetPoints(player2.GetName());
            } 
        }

        public void OutputResults() {
            foreach (string playerName in scores.Keys) {
                Console.WriteLine(playerName + " ==> " + scores[playerName]);
            }
        }

    }
}
