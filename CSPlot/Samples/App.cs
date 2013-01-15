using System;
using Xwt;
using Xwt.Drawing;

namespace Samples
{
	public class App
	{
		public static void Run (ToolkitType type)
		{
			Application.Initialize (type);
			
			MainWindow w = new MainWindow () {
			    Title = "ControlSuite - CSPlot Samples",
			    Width = 800,
			    Height = 600
            };
			w.Show ();
			
			Application.Run ();
			
			w.Dispose ();
		}
	}
}	

