using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Imagio.GUI.Controls
{
    public class PanningCanvas : ScrollViewer
    {
        #region Ctor

        public PanningCanvas()
        {
            friction = 1;
        }

        #endregion

        #region Data

        // Used when manually scrolling.
        private Point scrollTarget;
        private Point scrollStartPoint;
        private Point scrollStartOffset;
        private Point previousPoint;
        private Vector velocity;
        private double friction;

        #endregion

        #region Mouse Events

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            if (IsMouseOver && Keyboard.IsKeyDown(Key.Space))
            {
                // Save starting point, used later when determining how much to scroll.
                scrollStartPoint = e.GetPosition(this);
                scrollStartOffset.X = HorizontalOffset;
                scrollStartOffset.Y = VerticalOffset;

                // Update the cursor if can scroll or not.
                Cursor = (ExtentWidth > ViewportWidth) ||
                         (ExtentHeight > ViewportHeight)
                    ? Cursors.ScrollAll
                    : Cursors.Arrow;

                CaptureMouse();
            }

            base.OnPreviewMouseDown(e);
        }


        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            if (IsMouseCaptured && Keyboard.IsKeyDown(Key.Space))
            {
                var currentPoint = e.GetPosition(this);

                // Determine the new amount to scroll.
                var delta = new Point(scrollStartPoint.X - currentPoint.X, scrollStartPoint.Y - currentPoint.Y);

                scrollTarget.X = scrollStartOffset.X + delta.X;
                scrollTarget.Y = scrollStartOffset.Y + delta.Y;

                // Scroll to the new position.
                ScrollToHorizontalOffset(scrollTarget.X);
                ScrollToVerticalOffset(scrollTarget.Y);
            }

            base.OnPreviewMouseMove(e);
        }

        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            if (IsMouseCaptured && Keyboard.IsKeyDown(Key.Space))
            {
                Cursor = Cursors.Arrow;
                ReleaseMouseCapture();
            }

            base.OnPreviewMouseUp(e);
        }

        #endregion
    }
}