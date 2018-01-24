using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Imagio.Models
{
    internal class LineObject
    {
        private ConnectionNode _endNode;
        private bool _endNodeHandlerAdded;
        private ConnectionNode _startNode;
        private bool _startNodeHandlerAdded;

        public LineObject(Brush strokeColor, float thickness, ConnectionNode startNode, ConnectionNode endNode)
        {
            LinePath = new Path();
            LinePath.StrokeThickness = thickness;
            LinePath.Stroke = strokeColor;
            _lineGeometry = new LineGeometry(startNode.Location, endNode.Location);
            StartNode = startNode;
            EndNode = endNode;
        }

        public Path LinePath { get; set; }
        private LineGeometry _lineGeometry { get; }

        private ConnectionNode StartNode
        {
            get { return _startNode; }
            set
            {
                _startNode = value;
                _lineGeometry.StartPoint = value.Location;
                LinePath.Data = _lineGeometry;
                if (!_startNodeHandlerAdded)
                {
                    _startNodeHandlerAdded = true;
                    _startNode.UpdateLocation += _startNode_UpdateLocation;
                }
            }
        }

        private ConnectionNode EndNode
        {
            get { return _endNode; }
            set
            {
                _endNode = value;
                _lineGeometry.EndPoint = value.Location;
                LinePath.Data = _lineGeometry;
                if (!_endNodeHandlerAdded)
                {
                    _endNodeHandlerAdded = true;
                    _endNode.UpdateLocation += _endNode_UpdateLocation;
                    ;
                }
            }
        }

        private void _startNode_UpdateLocation(Point newLoc)
        {
            _lineGeometry.StartPoint = newLoc;
            LinePath.Data = _lineGeometry;
        }


        private void _endNode_UpdateLocation(Point newLoc)
        {
            _lineGeometry.EndPoint = newLoc;
            LinePath.Data = _lineGeometry;
        }
    }
}