// 
// CanvasWithWidget.cs
//  
// Author:
//       Lluis Sanchez <lluis@xamarin.com>
// 
// Copyright (c) 2011 Xamarin Inc
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using Xwt;
using Xwt.Drawing;

namespace Samples
{
	public class SimplePlotCanvas: VBox
	{
		public SimplePlotCanvas ()
		{
			PlotCanvas c = new PlotCanvas ();
			PackStart (c, BoxMode.FillAndExpand);
		}
	}

    /// <summary>
    /// PlotCanvas extends Canvas by maintaining an off-screen drawing area to which
    /// plots and axes are drawn, and from which the on-screen display is refreshed.
    /// </summary>	
	class PlotCanvas: Canvas
	{

        Rectangle bounds;

        double cursorX = 0;
        double cursorY = 0;
        bool cursorVisible = false;

        ImageBuilder plotCache;
        Image plotImage;
        Context cacheContext;


		public PlotCanvas ()
		{

        }
		
		protected override void OnDraw (Xwt.Drawing.Context ctx, Rectangle dirtyRect)
		{

            if (Bounds.IsEmpty)
				return;

            // Copy plotCache to on-screen display
            ctx.DrawImage (plotImage, dirtyRect);

            // draw some overlay over this
            DrawFocus (ctx, cursorX, cursorY);
			
		}

        void DrawFocus ( Context ctx, double x, double y )
        {
            if (!cursorVisible)
                return;

            double r = 16;

            ctx.Save ();

            x += 0.5;
            y += 0.5;
 
            ctx.SetLineWidth (3);
            ctx.SetColor (new Color (0, 0, 0, 0.5));
            ctx.Arc (x, y, r, 0, 360);
            ctx.Stroke ();

            ctx.SetLineWidth (1);

            ctx.MoveTo (x+r, y);
            ctx.RelLineTo (r, 0);
            ctx.MoveTo (x-r, y);
            ctx.RelLineTo (-r, 0);

            ctx.MoveTo (x, y+r);
            ctx.RelLineTo (0, r);
            ctx.MoveTo (x, y-r);
            ctx.RelLineTo (0, -r);
            ctx.Stroke ();

            r += 10;
            ctx.Arc (x, y, r, 10, 80);
            ctx.Stroke ();
            ctx.Arc (x, y, r, 100, 170);
            ctx.Stroke ();
            ctx.Arc (x, y, r, 190, 260);
            ctx.Stroke ();
            ctx.Arc (x, y, r, 280, 350);
            ctx.Stroke ();

 
            ctx.Restore ();
        }


        protected override void OnMouseMoved (MouseMovedEventArgs e)
        {
            cursorX = e.X;
            cursorY = e.Y;

            base.OnMouseMoved (e);

            QueueDraw ();
        }


        protected override void OnMouseEntered (EventArgs e)
        {
            cursorVisible = true;
            base.OnMouseEntered (e);
        }


        protected override void OnMouseExited (EventArgs e)
        {
            cursorVisible = false;
            base.OnMouseExited (e);
        }


        protected override void OnBoundsChanged ()
        {
            bounds = this.Bounds;

            if (plotCache != null ) {
                plotCache.Dispose ();
            }
            plotCache = new ImageBuilder ((int)bounds.Width, (int)bounds.Height, ImageFormat.ARGB32);
            cacheContext = plotCache.Context;
            UpdateCache (cacheContext);
            plotImage = plotCache.ToImage ();

            base.OnBoundsChanged ();
        }


        void UpdateCache (Context ctx )
        {
            // Draw 2 rectangles to represent plot cache contents
            // these are then copied to screen by OnDraw
            double x = bounds.Width/2 - 50 + 0.5;
            double y = bounds.Height/2 - 50 + 0.5;

            ctx.Save ();
            ctx.SetColor (Colors.Blue);
            ctx.SetLineWidth (3);
            ctx.Rectangle (x, y, 100, 100);
            ctx.Rectangle (x+10, y+10, 80, 80);
            ctx.Stroke ();
            ctx.Restore ();
        }
   
	}
}

