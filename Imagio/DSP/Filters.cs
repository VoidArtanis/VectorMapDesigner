using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Imagio.DSP
{
    public class Filters
    {
        public double[] CleanData(double[] noisy, int range, double decay)
        {
            var clean = new double[noisy.Length];
            var coefficients = Coefficients(range, decay);

            double divisor = 0;
            for (var i = -range; i <= range; i++)
                divisor += coefficients[Math.Abs(i)];

            for (var i = range; i < clean.Length - range; i++)
            {
                double temp = 0;
                for (var j = -range; j <= range; j++)
                    temp += noisy[i + j]*coefficients[Math.Abs(j)];
                clean[i] = temp/divisor;
            }

            double leadSum = 0;
            double trailSum = 0;
            var leadRef = range;
            var trailRef = clean.Length - range - 1;
            for (var i = 1; i <= range; i++)
            {
                leadSum += (clean[leadRef] - clean[leadRef + i])/i;
                trailSum += (clean[trailRef] - clean[trailRef - i])/i;
            }
            var leadSlope = leadSum/range;
            var trailSlope = trailSum/range;

            for (var i = 1; i <= range; i++)
            {
                clean[leadRef - i] = clean[leadRef] + leadSlope*i;
                clean[trailRef + i] = clean[trailRef] + trailSlope*i;
            }
            return clean;
        }

        public List<Point> GetNeighbors(List<Point> pts, int OneSideRange, int position)
        {
            var neighbors = new List<Point>();
            var min = position - OneSideRange >= 0 ? position - OneSideRange : 0;
            var max = position + OneSideRange <= pts.Count ? position + OneSideRange : pts.Count;
            for (var i = position; i > min; i--)
            {
                neighbors.Add(pts[i]);
            }
            for (var i = position + 1; i < max; i++)
            {
                neighbors.Add(pts[i]);
            }
            return neighbors;
        }

        public List<Point> DoMedianFitler(List<Point> pts)
        {
            var points = new List<Point>();

            for (var index = 0; index < pts.Count; index++)
            {
                var n = GetNeighbors(pts, 3, index);
                var x_avg = n.Select(q => q.X).Average();
                var y_avg = n.Select(q => q.Y).Average();
                points.Add(new Point(x_avg, y_avg));
            }

            return points;
        }

        private double[] Coefficients(int range, double decay)
        {
            // Precalculate coefficients.
            var coefficients = new double[range + 1];
            for (var i = 0; i <= range; i++)
                coefficients[i] = Math.Pow(decay, i);
            return coefficients;
        }
    }
}