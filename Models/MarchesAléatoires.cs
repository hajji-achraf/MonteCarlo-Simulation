using System.Collections.Generic;
using System.Drawing;

namespace MonteCarlo_Simulation.Models
{
    public class MarchesAléatoires
    {
        Random random;

        // Constructeur
        public MarchesAléatoires()
        {
            random = new Random();
        }

        // Méthode pour générer une trajectoire en 2D
        public List<Point> GenerateTrajectory2D(int steps)
        {
            var points = new List<Point> { new Point(0, 0) }; // Commence à l'origine (0, 0)
            int x = 0, y = 0;

            for (int i = 0; i < steps; i++)
            {
                var direction = random.Next(4); // Génère un nombre aléatoire entre 0 et 3
                switch (direction)
                {
                    case 0: y++; break; // Monter
                    case 1: y--; break; // Descendre
                    case 2: x++; break; // Aller à droite
                    case 3: x--; break; // Aller à gauche
                }

                points.Add(new Point(x, y)); // Ajoute le nouveau point à la liste
            }

            return points;
        }
    }
}
