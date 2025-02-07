using System;

namespace MonteCarlo_Simulation.Models
{
    public class PricingOptions
    {
        public double S0 { get; set; }  // Prix initial
        public double K { get; set; }   // Prix d'exercice
        public double T { get; set; }   // Maturité
        public double r { get; set; }   // Taux d'intérêt
        public double sigma { get; set; }  // Volatilité
        public int N { get; set; } = 10000; // Nombre de simulations Monte Carlo
        public bool IsCall { get; set; } = true; // Type d'option (true = Call, false = Put)


        public double BlackScholesPrice { get; private set; }
        public double MonteCarloPrice { get; private set; }


        public void CalculatePrices()
        {
            BlackScholesPrice = CalculateBlackScholes();
            MonteCarloPrice = SimulateMonteCarlo();
        }

        private double CalculateBlackScholes()
        {
            double d1 = (Math.Log(S0 / K) + (r + 0.5 * sigma * sigma) * T) /
                        (sigma * Math.Sqrt(T));

            double d2 = d1 - sigma * Math.Sqrt(T);

            double Nd1 = NormalCdf(d1);

            double Nd2 = NormalCdf(d2);

            if (IsCall)
            {
                return S0 * Nd1 - K * Math.Exp(-r * T) * Nd2;
            }
            else
            {
                return K * Math.Exp(-r * T) * NormalCdf(-d2) - S0 * NormalCdf(-d1);
            }
        }

        private double SimulateMonteCarlo()
        {
            Random rand = new Random();

            double sumPayoff = 0;

            for (int i = 0; i < N; i++)
            {
                double Z = NormalRandom(); // Génération d’un Z ~ N(0,1)

                double ST = S0 * Math.Exp((r - 0.5 * sigma * sigma) * T + sigma * Math.Sqrt(T) * Z);

                if (IsCall)
                    sumPayoff += Math.Max(ST - K, 0);
                else
                    sumPayoff += Math.Max(K - ST, 0);
            }

            return Math.Exp(-r * T) * (sumPayoff / N);
        }

        private double NormalCdf(double x)
        {
            return 0.5 * (1.0 + Erf(x / Math.Sqrt(2)));
        }

        private double Erf(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = x < 0 ? -1 : 1;
            x = Math.Abs(x);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return sign * y;
        }

        private double NormalRandom()
        {
            Random rand = new Random();
            double u1 = rand.NextDouble();
            double u2 = rand.NextDouble();
            return Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
        }
    }
}
