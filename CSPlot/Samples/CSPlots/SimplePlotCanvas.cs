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

	
	class PlotCanvas: Canvas
	{
		Rectangle rect = new Rectangle (30, 30, 100, 30);

		public PlotCanvas ()
		{

            var box = new HBox ();
			box.PackStart (new Button ("Button"));
			AddChild (box, new Rectangle (30, 70, 100, 30));

        }
		
		protected override void OnDraw (Xwt.Drawing.Context ctx, Rectangle dirtyRect)
		{

            if (Bounds.IsEmpty)
				return;

			ctx.Rectangle (0, 0, Bounds.Width, Bounds.Height);
			Gradient g = new LinearGradient (0, 0, Bounds.Width, Bounds.Height);
			g.AddColorStop (0, new Color (1, 0, 0));
			g.AddColorStop (1, new Color (0, 1, 0));
			ctx.Pattern = g;
			ctx.Fill ();
			
		}
	}
}

