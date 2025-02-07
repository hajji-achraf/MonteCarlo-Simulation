using System;

namespace MonteCarlo_Simulation.Models
{
    public class SimulationLois
    {
        private static readonly Random random = new Random();

        // Fonction pour générer une loi uniforme sur [a, b]
        public static double[] LoiUniforme(double a, double b, int n)
        {
            double[] resultats = new double[n];
            for (int i = 0; i < n; i++)
            {
                resultats[i] = Math.Round(a + (b - a) * random.NextDouble(), 2); // Arrondir à 2 chiffres après la virgule
            }
            return resultats;
        }

        // Fonction pour générer une loi exponentielle de paramètre lambda
        public static double[] LoiExponentielle(double lambda, int n)
        {
            double[] resultats = new double[n];
            for (int i = 0; i < n; i++)
            {
                resultats[i] = Math.Round(-1 / lambda * Math.Log(1 - random.NextDouble()), 2); // Arrondir à 2 chiffres après la virgule
            }
            return resultats;
        }

        // Fonction pour générer une loi de Cauchy de paramètre c
        public static double[] LoiCauchy(double c, int n)
        {
            double[] resultats = new double[n];
            for (int i = 0; i < n; i++)
            {
                resultats[i] = Math.Round(c * Math.Tan(Math.PI * (random.NextDouble() - 0.5)), 2); // Arrondir à 2 chiffres après la virgule
            }
            return resultats;
        }

        // Fonction pour générer une loi de Bernoulli de paramètre p
        public static int[] LoiBernoulli(double p, int n)
        {
            int[] resultats = new int[n];
            for (int i = 0; i < n; i++)
            {
                resultats[i] = random.NextDouble() < p ? 1 : 0;
            }
            return resultats;
        }

        // Fonction pour générer une loi normale N(0, 1) avec la méthode de Box-Muller
        public static double[] LoiNormale(double mu, double sigma, int n)
        {
            double[] resultats = new double[n];
            int i = 0;
            while (i < n)
            {
                double u1 = random.NextDouble();
                double u2 = random.NextDouble();
                double x1 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
                double x2 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);
                if (x1 != 0)
                {
                    resultats[i++] = Math.Round(mu + sigma * x1, 2); // Arrondir à 2 chiffres après la virgule
                }
                if (i < n && x2 != 0)
                {
                    resultats[i++] = Math.Round(mu + sigma * x2, 2); // Arrondir à 2 chiffres après la virgule
                }
            }
            return resultats;
        }
    }
}
