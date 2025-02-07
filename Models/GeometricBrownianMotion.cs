public class GeometricBrownianMotion
{
    private Random random;
    private double deltaT;
    private double drift;
    private double volatility;

    public GeometricBrownianMotion(double deltaT, double drift, double volatility)
    {
        // Validation des paramètres
        if (deltaT <= 0)
            throw new ArgumentException("deltaT doit être positif");
        if (volatility < 0)
            throw new ArgumentException("La volatilité doit être positive ou nulle");

        // Conversion des pourcentages en décimaux si nécessaire
        if (volatility > 1)
            volatility /= 100;

        this.deltaT = deltaT;
        this.drift = drift;
        this.volatility = volatility;
        random = new Random();
    }

    private double GenerateDisplacement()
    {
        double u1 = random.NextDouble();
        double u2 = random.NextDouble();
        double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
        return z * Math.Sqrt(deltaT);
    }

    public double[] SimulateGBM(double initialPrice, int steps)
    {
        double[] path = new double[steps];
        path[0] = initialPrice; // Assurez-vous que le premier point est le prix initial

        double currentPrice = initialPrice;
        double driftTerm = (drift - 0.5 * Math.Pow(volatility, 2)) * deltaT;

        for (int i = 1; i < steps; i++) // Commencez à i=1 puisque i=0 est déjà défini
        {
            double brownianIncrement = GenerateDisplacement();
            currentPrice = currentPrice * Math.Exp(driftTerm + volatility * brownianIncrement);
            path[i] = currentPrice;
        }

        return path;
    }

    public double[][] SimulateMultiplePaths(double initialPrice, int steps, int numSimulations)
    {
        double[][] paths = new double[numSimulations][];
        Parallel.For(0, numSimulations, i =>
        {
            paths[i] = SimulateGBM(initialPrice, steps);
        });
        return paths;
    }
}