using System;
using System.Collections;

namespace PD {
    class Match {
        private Player first;
        private Player second;
        private Hashtable points;
        private Hashtable results;

        public Player FirstPlayer {
            get { return first; }
        }

        public Player SecondPlayer {
            get { return second; }
        }

        public int GetPoints(string playerName) {
            return (int)points[playerName];
        }

        public PlayResult GetResult(string playerName) {
            return (PlayResult)results[playerName];
        }

        public Match() {
            points = new Hashtable();
            results = new Hashtable();
        }

        public Match(Player player1, Player player2) : this() {
            first = player1;
            second = player2;
        }

        public Player GetOpponent(Player player) {
            if (player.GetName().Equals(first.GetName())) {
                return second;
            } else {
                return first;
            }
        }

        public void PlayMatch() {
            PlayResult res1 = first.Play(second);
            PlayResult res2 = second.Play(first);
            int firstPoints = 0;
            int secondPoints = 0;

            if (res1 == PlayResult.Cooperate) {
                if (res2 == PlayResult.Cooperate) {
                    firstPoints = 3;
                    secondPoints = 3;
                } else if (res2 == PlayResult.Defect){
                    firstPoints = 0;
                    secondPoints = 5;
                }
            } else if (res1 == PlayResult.Defect) {
                if (res2 == PlayResult.Cooperate) {
                    firstPoints = 5;
                    secondPoints = 0;
                } else if (res2 == PlayResult.Defect){
                    firstPoints = 1;
                    secondPoints = 1;
                }                
            }

            points.Add(first.GetName(), firstPoints);
            points.Add(second.GetName(), secondPoints);

            results.Add(first.GetName(), res1);
            results.Add(second.GetName(), res2);
        }
    }
}
