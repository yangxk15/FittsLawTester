using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FittsLawTester
{
    /// <summary>
    /// Interaction logic for Part3.xaml
    /// </summary>
    public partial class Part3 : Page
    {
        private int current;
        private List<Trial> trialList;
        private List<Ellipse> points;

        public Part3()
        {
            InitializeComponent();
            trialList = new List<Trial>();
            points = new List<Ellipse>();
            current = -1;
            String path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Part3.txt";
            if (!File.Exists(path))
            {
                MessageBox.Show("There is no trajectory file!");
                this.NavigationService.GoBack();
            }
            using (StreamReader sr = new StreamReader(path))
            {
                //read the first line
                String line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    String[] sl = line.Split(' ');
                    if (Int32.Parse(sl[1]) != (current + 1))
                    {
                        current++;
                        trialList.Add(new Trial(Int32.Parse(sl[0]), Int32.Parse(sl[2]), Int32.Parse(sl[3])));
                        trialList[current].startPos = Point.Parse(sl[4].Substring(1, sl[4].Length - 2));
                        trialList[current].endPos = Point.Parse(sl[5].Substring(1, sl[5].Length - 2));
                        trialList[current].success = Int32.Parse(sl[7]);
                    }
                    trialList[current].timePos.Add(Double.Parse(sl[6]));
                    trialList[current].cursorPos.Add(Point.Parse(sl[8].Substring(1, sl[8].Length - 2)));
                }
            }
            current = 0;
            Show();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            current++;
            Show();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            current--;
            Show();
        }

        private void Show()
        {
            Trial trial = trialList[current];
            this.Trial.Content = "Trial #: " + (current + 1).ToString();
            this.Time.Content = "Time: " + trial.timePos.Last().ToString() + "ms";
            this.Start.Margin = new Thickness(trial.startPos.X - this.Start.Width / 2, trial.startPos.Y - this.Start.Height / 2, 0, 0);
            this.Target.Height = this.Target.Width = trial.width;
            this.Target.Margin = new Thickness(trial.endPos.X - this.Target.Width / 2, trial.endPos.Y - this.Target.Height / 2, 0, 0);
            foreach (Ellipse e in points)
            {
                this.Grid.Children.Remove(e);
            }
            points.Clear();
            foreach (Point p in trial.cursorPos)
            {
                Ellipse e = new Ellipse();
                e.HorizontalAlignment = HorizontalAlignment.Left;
                e.VerticalAlignment = VerticalAlignment.Top;
                e.Fill = Brushes.Red;
                e.Height = e.Width = 5;
                e.Margin = new Thickness(p.X - e.Width / 2, p.Y - e.Height / 2, 0, 0);
                this.Grid.Children.Add(e);
                points.Add(e);
            }
            this.Previous.IsEnabled = current <= 0 ? false : true;
            this.Next.IsEnabled = current >= trialList.Count - 1 ? false : true;
        }
    }
}
