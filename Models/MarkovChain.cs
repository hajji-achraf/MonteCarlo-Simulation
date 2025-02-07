using System;
using System.Collections.Generic;

namespace MonteCarlo_Simulation.Models
{
    public class MarkovChain
    {
        private double[,] _transitionMatrix; // Matrice de transition
        private Random _random;             // Générateur aléatoire

        public MarkovChain(double[,] transitionMatrix)
        {
            _transitionMatrix = transitionMatrix;
            _random = new Random();
        }

        // Simulation Synchrone
        public List<int> SimulateSync(int steps, int initialState)
        {
            List<int> path = new List<int> { initialState }; // Chemin parcouru
            int currentState = initialState;

            for (int i = 0; i < steps; i++)
            {
                currentState = GetNextState(currentState); // Transition au prochain état
                path.Add(currentState);
            }

            return path;
        }

        // Simulation Asynchrone
        public List<int> SimulateAsync(int maxTransitions, int initialState)
        {
            List<int> path = new List<int> { initialState };
            int currentState = initialState;
            int totalTransitions = 0;

            while (totalTransitions < maxTransitions)
            {
                int timeToNextEvent = GetGeometricRandom(1 - _transitionMatrix[currentState, currentState]);
                totalTransitions += timeToNextEvent;

                currentState = GetNextState(currentState); // Transition au prochain état
                path.Add(currentState);
            }

            return path;
        }

        // Obtenir le prochain état
        private int GetNextState(int currentState)
        {
            double rand = _random.NextDouble();
            double cumulative = 0;

            for (int i = 0; i < _transitionMatrix.GetLength(1); i++)
            {
                cumulative += _transitionMatrix[currentState, i];
                if (rand < cumulative)
                {
                    return i;
                }
            }

            return currentState; // Sécurité si rien n'est trouvé
        }

        // Générer un temps géométrique
        private int GetGeometricRandom(double p)
        {
            return (int)Math.Ceiling(Math.Log(1 - _random.NextDouble()) / Math.Log(1 - p));
        }
    }


}

