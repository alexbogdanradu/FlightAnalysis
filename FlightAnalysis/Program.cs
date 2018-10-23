using NPlot;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace FlightAnalysis
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //string file = File.ReadAllText(@"C:\Users\abradu\Desktop\Personal\Flights\284F4A90C57F3FA3E04E364FE6ACB925.json");
            string file = File.ReadAllText(@"C:\Users\abradu\Desktop\Personal\Flights\20056AD50DEFACE5A912E9076752BA70.json");

            Blackbox bb = new JavaScriptSerializer().Deserialize<Blackbox>(file);
            bb.ConvertToNatives();
            bb.SVT();

            for (int i = 0; i < bb.altitude.Count; i++)
            {
                bb.altitude[i] = bb.altitude[i] / 1000;
            }

            NPlot.Bitmap.PlotSurface2D npSurface = new NPlot.Bitmap.PlotSurface2D(10000, 1000);
            NPlot.LinePlot npPlot1 = new LinePlot();
            NPlot.LinePlot npPlot2 = new LinePlot();
            NPlot.LinePlot npPlot3 = new LinePlot();
            NPlot.LinePlot npPlot4 = new LinePlot();
            NPlot.LinePlot npPlot5 = new LinePlot();

            npSurface.Clear();
            npSurface.Title = "Line Graph";
            npSurface.BackColor = System.Drawing.Color.White;

            //Left Y axis grid:
            NPlot.Grid p = new Grid();
            NPlot.HistogramPlot h = new HistogramPlot();
            npSurface.Add(p, NPlot.PlotSurface2D.XAxisPosition.Bottom,
                          NPlot.PlotSurface2D.YAxisPosition.Left);

            //Phi:
            npPlot1.AbscissaData = bb.time;
            npPlot1.DataSource = bb.angle_phi;
            npPlot1.Label = "Phi";
            npPlot1.Color = System.Drawing.Color.Blue;

            npSurface.Add(npPlot1, NPlot.PlotSurface2D.XAxisPosition.Bottom,
                  NPlot.PlotSurface2D.YAxisPosition.Left);

            //Phi:
            npPlot2.AbscissaData = bb.time;
            npPlot2.DataSource = bb.angle_psi;
            npPlot2.Label = "Psi";
            npPlot2.Color = System.Drawing.Color.Red;

            npSurface.Add(npPlot2, NPlot.PlotSurface2D.XAxisPosition.Bottom,
                  NPlot.PlotSurface2D.YAxisPosition.Left);

            //Theta:
            npPlot3.AbscissaData = bb.time;
            npPlot3.DataSource = bb.angle_theta;
            npPlot3.Label = "Theta";
            npPlot3.Color = System.Drawing.Color.Green;

            npSurface.Add(npPlot3, NPlot.PlotSurface2D.XAxisPosition.Bottom,
                  NPlot.PlotSurface2D.YAxisPosition.Left);

            //Speed:
            npPlot4.AbscissaData = bb.time;
            npPlot4.DataSource = bb.SpeedVsTheta;
            npPlot4.Label = "Speed";
            npPlot4.Color = System.Drawing.Color.Black;

            npSurface.Add(npPlot4, NPlot.PlotSurface2D.XAxisPosition.Bottom,
                  NPlot.PlotSurface2D.YAxisPosition.Left);

            ////Alti:
            //npPlot5.AbscissaData = bb.time;
            //npPlot5.DataSource = bb.altitude;
            //npPlot5.Label = "Alt";
            //npPlot5.Color = System.Drawing.Color.Orange;

            //npSurface.Add(npPlot5, NPlot.PlotSurface2D.XAxisPosition.Bottom,
            //      NPlot.PlotSurface2D.YAxisPosition.Left);

            npSurface.Refresh();

            MemoryStream memStream = new MemoryStream();

            npSurface.Bitmap.Save(memStream, System.Drawing.Imaging.ImageFormat.Gif);

            FileStream fs = new FileStream(@"D:\file.gif", FileMode.Create);

            memStream.WriteTo(fs);
            
            //Console.WriteLine("Done");
            //Console.ReadLine();
        }
    }
}
