using System;
using System.Collections.Generic;
using Engine.Interfaces;
using Microsoft.Xna.Framework;


namespace Engine.Xna
{
    public class XnaLayoutManager : ILayoutManager
    {
        public XnaRenderer Renderer { get; set; }



        public XnaLayoutManager(XnaRenderer renderer)
        {
            Renderer = renderer;
            XnaLayouts = new List<XnaLayout>();

        }

        public ILayout CreateLayout(int width, int height)
        {
            var xnaLayout = new XnaLayout(this, width, height);
            XnaLayouts.Add(xnaLayout);
            return xnaLayout;
        }


        protected List<XnaLayout> XnaLayouts { get; set; }

        public IEnumerable<ILayout> Layouts { get { return XnaLayouts; } }

        public bool OneLayoutAtATime { get; set; }

        public XnaLayout CurrentLayout
        {
            get
            {
                foreach (var xnaLayout in XnaLayouts)
                {
                    if (xnaLayout.Active)
                    {
                        return xnaLayout;
                    }
                }
                return null;
            }
        }

        public void Draw(TimeSpan elapsedGameTime)
        {
            if (OneLayoutAtATime)
            {
                CurrentLayout.LayoutView.Render(elapsedGameTime);
            }
            else
            {
                foreach (var xnaLayout in XnaLayouts)
                {

                    xnaLayout.LayoutView.Render(elapsedGameTime);
                }
            }
        }
        public void Tick(TimeSpan elapsedGameTime)
        {
            if (OneLayoutAtATime)
            {
                CurrentLayout.LayoutView.Tick(elapsedGameTime);

                foreach (var xnaLayout in XnaLayouts)
                {
                    if (xnaLayout.AlwaysTick && CurrentLayout != xnaLayout)
                        xnaLayout.LayoutView.Tick(elapsedGameTime);
                }

            }
            else
            {
                foreach (var xnaLayout in XnaLayouts)
                {
                    xnaLayout.LayoutView.Tick(elapsedGameTime);
                }
            }

        }

        public Size GetLayoutSize()
        {
            if (OneLayoutAtATime)
            {
                return new Size(CurrentLayout.Width, CurrentLayout.Height);
            }
            else
            {
                Size size = new Size();

                foreach (var layout in Layouts)
                {
                    var rectangle = layout.LayoutPosition.Location;
                    if (size.Width < rectangle.X + rectangle.Width)
                    {
                        size.Width = rectangle.X + rectangle.Width;
                    }
                    if (size.Height < rectangle.Y + rectangle.Height)
                    {
                        size.Height = rectangle.Y + rectangle.Height;
                    }
                }
                return size;
            }


        }

        public void ChangeLayout(Direction direction)
        {
            if (OneLayoutAtATime)
            {
                switch (direction)
                {
                    case Direction.Left:
                        if (CurrentLayout.LayoutPosition.Left != null)
                            ChangeLayout(CurrentLayout.LayoutPosition.Left);
                        break;
                    case Direction.Right:
                        if (CurrentLayout.LayoutPosition.Right != null)
                            ChangeLayout(CurrentLayout.LayoutPosition.Right);

                        break;
                    case Direction.Up:
                        if (CurrentLayout.LayoutPosition.Top != null)
                            ChangeLayout(CurrentLayout.LayoutPosition.Top);
                        break;
                    case Direction.Down:
                        if (CurrentLayout.LayoutPosition.Bottom != null)
                            ChangeLayout(CurrentLayout.LayoutPosition.Bottom);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("direction");
                }
            }
        }

        public void ChangeLayout(ILayout changeTo)
        {
            changeTo.Active = true;
            Renderer.graphics.SupportedOrientations = SupportedOrientations(changeTo);
            Renderer.graphics.ApplyChanges();
        }

        private static DisplayOrientation SupportedOrientations(ILayout changeTo)
        {
            switch (changeTo.ScreenOrientation)
            {
                case ScreenOrientation.Vertical:
                    return DisplayOrientation.Portrait | DisplayOrientation.PortraitDown;
                case ScreenOrientation.Horizontal:
                    return DisplayOrientation.LandscapeRight | DisplayOrientation.LandscapeLeft;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        public void TouchEvent(TouchType touchType, int x, int y)
        {
            if (OneLayoutAtATime)
            {
                CurrentLayout.LayoutView.TouchManager.ProcessTouchEvent(touchType, x, y);
            }
            else
            {
                foreach (var xnaLayout in XnaLayouts)
                {
                    var rectangle = xnaLayout.LayoutPosition.Location;
                    if (rectangle.IsInside(new Point(x, y)))
                    {
                        xnaLayout.LayoutView.TouchManager.ProcessTouchEvent(touchType, x - rectangle.X, y - rectangle.Y);

                    }
                }
            }

        }
    }
}