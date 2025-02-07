
    namespace MonteCarlo_Simulation.Models
    {
        using System;

        public class BrownianMotion
        {
            private Random random;  // Générateur de nombres aléatoires
            private double deltaT;  // Pas de temps Δt
            private double drift;   // Drift (μ)
            private double volatility; // Volatilité (σ)




            // Constructeur
            public BrownianMotion(double deltaT, double drift, double volatility)
            {
                this.deltaT = deltaT;
                this.drift = drift;
                this.volatility = volatility;
                random = new Random();  // Initialisation du générateur aléatoire
            }

            // Méthode pour générer un déplacement suivant N(0, Δt)
            private double GenerateDisplacement()
            {
                // Utilisation de la méthode de Box-Muller pour générer une loi normale
                double u1 = random.NextDouble(); // Uniforme [0, 1]
                double u2 = random.NextDouble(); // Uniforme [0, 1]

                // Transformation pour obtenir une loi normale standard N(0, 1)
                double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

                // Ajustement à N(0, Δt)
                return z * Math.Sqrt(deltaT);
            }

            // Méthode pour générer une trajectoire unique
            public double[] GenerateTrajectory(int steps)
            {
                double[] trajectory = new double[steps];
                double currentValue = 0; // Point de départ (peut être ajusté si nécessaire)

                for (int i = 0; i < steps; i++)
                {
                    // Calcul du prochain point : Xt+1 = Xt + μΔt + σW
                    double displacement = GenerateDisplacement();
                    currentValue += drift * deltaT + volatility * displacement;
                    trajectory[i] = currentValue;
                }

                return trajectory;
            }

            // Méthode pour générer plusieurs trajectoires
            public double[][] GenerateMultipleTrajectories(int simulations, int steps)
            {
                double[][] trajectories = new double[simulations][];

                for (int i = 0; i < simulations; i++)
                {
                    trajectories[i] = GenerateTrajectory(steps);
                }

                return trajectories;
            }
        }
    }



