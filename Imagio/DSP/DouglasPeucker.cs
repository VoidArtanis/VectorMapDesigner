﻿using System;
using System.Collections.Generic;
using System.Windows;

namespace Imagio.DSP
{
    internal class DouglasPeucker
    { 
        /// Uses the Douglas Peucker algorithm to reduce the number of points.
       
        public List<Point> DouglasPeuckerReduction
            (List<Point> Points, double Tolerance)
        {
            if (Points == null || Points.Count < 3)
                return Points;

            var firstPoint = 0;
            var lastPoint = Points.Count - 1;
            var pointIndexsToKeep = new List<int>();

            //Add the first and last index to the keepers
            pointIndexsToKeep.Add(firstPoint);
            pointIndexsToKeep.Add(lastPoint);

            //The first and the last point cannot be the same
            while (Points[firstPoint].Equals(Points[lastPoint]))
            {
                lastPoint--;
            }

            DouglasPeuckerReduction(Points, firstPoint, lastPoint,
                Tolerance, ref pointIndexsToKeep);

            var returnPoints = new List<Point>();
            pointIndexsToKeep.Sort();
            foreach (var index in pointIndexsToKeep)
            {
                returnPoints.Add(Points[index]);
            }

            return returnPoints;
        }

        /// <span class="code-SummaryComment">
        ///     <summary>
        /// </span>
        /// Douglases the peucker reduction.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment">
        ///     <param name="points">The points.</param>
        /// </span>
        /// <span class="code-SummaryComment">
        ///     <param name="firstPoint">The first point.</param>
        /// </span>
        /// <span class="code-SummaryComment">
        ///     <param name="lastPoint">The last point.</param>
        /// </span>
        /// <span class="code-SummaryComment">
        ///     <param name="tolerance">The tolerance.</param>
        /// </span>
        /// <span class="code-SummaryComment">
        ///     <param name="pointIndexsToKeep">The point index to keep.</param>
        /// </span>
        private void DouglasPeuckerReduction(List<Point>
            points, int firstPoint, int lastPoint, double tolerance,
            ref List<int> pointIndexsToKeep)
        {
            double maxDistance = 0;
            var indexFarthest = 0;

            for (var index = firstPoint; index < lastPoint; index++)
            {
                var distance = PerpendicularDistance
                    (points[firstPoint], points[lastPoint], points[index]);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    indexFarthest = index;
                }
            }

            if (maxDistance > tolerance && indexFarthest != 0)
            {
                //Add the largest point that exceeds the tolerance
                pointIndexsToKeep.Add(indexFarthest);

                DouglasPeuckerReduction(points, firstPoint,
                    indexFarthest, tolerance, ref pointIndexsToKeep);
                DouglasPeuckerReduction(points, indexFarthest,
                    lastPoint, tolerance, ref pointIndexsToKeep);
            }
        }

        /// <span class="code-SummaryComment">
        ///     <summary>
        /// </span>
        /// The distance of a point from a line made from point1 and point2.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment">
        ///     <param name="pt1">The PT1.</param>
        /// </span>
        /// <span class="code-SummaryComment">
        ///     <param name="pt2">The PT2.</param>
        /// </span>
        /// <span class="code-SummaryComment">
        ///     <param name="p">The p.</param>
        /// </span>
        /// <span class="code-SummaryComment">
        ///     <returns></returns>
        /// </span>
        public double PerpendicularDistance
            (Point Point1, Point Point2, Point Point)
        {
            //Area = |(1/2)(x1y2 + x2y3 + x3y1 - x2y1 - x3y2 - x1y3)|   *Area of triangle
            //Base = v((x1-x2)²+(x1-x2)²)                               *Base of Triangle*
            //Area = .5*Base*H                                          *Solve for height
            //Height = Area/.5/Base

            var area = Math.Abs(.5*(Point1.X*Point2.Y + Point2.X*
                                    Point.Y + Point.X*Point1.Y - Point2.X*Point1.Y - Point.X*
                                    Point2.Y - Point1.X*Point.Y));
            var bottom = Math.Sqrt(Math.Pow(Point1.X - Point2.X, 2) +
                                   Math.Pow(Point1.Y - Point2.Y, 2));
            var height = area/bottom*2;

            return height;

            //Another option
            //Double A = Point.X - Point1.X;
            //Double B = Point.Y - Point1.Y;
            //Double C = Point2.X - Point1.X;
            //Double D = Point2.Y - Point1.Y;

            //Double dot = A * C + B * D;
            //Double len_sq = C * C + D * D;
            //Double param = dot / len_sq;

            //Double xx, yy;

            //if (param < 0)
            //{
            //    xx = Point1.X;
            //    yy = Point1.Y;
            //}
            //else if (param > 1)
            //{
            //    xx = Point2.X;
            //    yy = Point2.Y;
            //}
            //else
            //{
            //    xx = Point1.X + param * C;
            //    yy = Point1.Y + param * D;
            //}

            //Double d = DistanceBetweenOn2DPlane(Point, new Point(xx, yy));
        }
    }
}