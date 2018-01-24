using System.Windows;
using System.Windows.Media;

namespace Imagio.Models
{
    internal class ConnectionNode : LineObject
    {
        public delegate void _updateLocation(Point newLoc);

        public ConnectionNode(Brush strokeColor, float thickness, ConnectionNode startNode, ConnectionNode endNode)
            : base(strokeColor, thickness, startNode, endNode)
        {
        }

        public Point Location { get; private set; }

        public event _updateLocation UpdateLocation;

        public void ChangeLocation(Point newLoc)
        {
            if (UpdateLocation != null)
            {
                UpdateLocation(newLoc);
            }
            Location = newLoc;
        }
    }
}