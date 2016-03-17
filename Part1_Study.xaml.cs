using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace FittsLawTester
{
    /// <summary>
    /// Interaction logic for Part1_Study.xaml
    /// </summary>
    public class Trial
    {
        public int subjectID { get; set; }
        public Point startPos { get; set; }
        public Point endPos { get; set; }
        public int success { get; set; }
        public int time { get; set; }
        public int amplitude { get; set; }
        public int width { get; set; }
        public List<Point> cursorPos;
        public List<double> timePos;
        public Trial(int id, int a, int w)
        {
            this.subjectID = id;
            this.amplitude = a;
            this.width = w;
            this.cursorPos = new List<Point>();
            this.timePos = new List<double>();
        }
    }
    public partial class Part1_Study : Page
    {
        public delegate void nextTrialDelegate();
        private Study study;
        private List<Trial> trialList;
        private int current;
        private double start_time;
        private double end_time;
        private int state;
        private DispatcherTimer timer;
        public Part1_Study()
        {
            InitializeComponent();
        }
        public Part1_Study(Study s)
        {
            InitializeComponent();
            this.study = s;
            generalizeList();
            this.current = 0;
            timer = new DispatcherTimer();
            timer.Tick += getCursorPos;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            test();
        }

        private void generalizeList()
        {
            //initialize trialList
            trialList = new List<Trial>();
            foreach (var i in study.amplitudes_list)
            {
                foreach (var j in study.widths_list)
                {
                    for (int k = 0; k < study.trials_per_condition; k++)
                        trialList.Add(new Trial(study.subject_id.Value, i, j));
                }
            }
            
            //shuffle trialList
            for (int i = trialList.Count; i > 1; i--)
            {
                Random rd = new Random();
                int j = rd.Next() % i;
                Trial temp = trialList[i - 1];
                trialList[i - 1] = trialList[j];
                trialList[j] = temp;
            }
            
        }

        private void test()
        {
            Thread.Sleep(1000);

            Trial trial = trialList[current];
            double startX = 0;
            double startY = 0;
            double x = 0;
            double y = 0;
            double l = trial.amplitude;
            double d = trial.width / 2;
            int p = 1;
            while (p == 1)
            {
                startX = new Random().NextDouble() * (this.Grid.Width - this.Start.Width);
                startY = new Random().NextDouble() * (this.Grid.Height - this.Start.Height);
                if (startX < this.label.Width || startY < this.label.Height)
                    continue;
                double a = Math.Max(startX, this.Grid.Width - startX);
                double b = Math.Max(startY, this.Grid.Height - startY);
                if (a * a + b * b > (l + d) * (l + d))
                    break;
            }
            while (p == 1)
            {
                double angle = new Random().NextDouble() * Math.PI / 2;
                x = startX + l * Math.Cos(angle) * (startX < this.Grid.Width  / 2 ? 1 : -1);
                y = startY + l * Math.Sin(angle) * (startY < this.Grid.Height / 2 ? 1 : -1);
                if (x - d >= 0 && x + d <= this.Grid.Width && y - d >= 0 && y + d <= this.Grid.Height
                    && (x - d >= this.label.Width || y - d >= this.label.Height))
                {
                    this.Start.Margin = new Thickness(startX - this.Start.Width / 2, startY - this.Start.Height / 2, 0, 0);
                    this.Target.Margin = new Thickness(x - d, y - d, 0, 0);
                    break;
                }
            }
            this.Target.Height = this.Target.Width = trial.width;

            this.Start.IsEnabled = true;

            this.state = 0;

            trial.startPos = new Point(Math.Round(startX), Math.Round(startY));
            trial.endPos = new Point(Math.Round(x), Math.Round(y));

            this.Time.Content = "";
            this.Time.Margin = new Thickness(0);
            this.Start.Background = Brushes.Black;
            this.Start.Foreground = Brushes.White;
            this.label.Content = (trialList.Count - current).ToString() + " trials left";
        }

        

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (state == 0)
            {
                start_time = new TimeSpan(DateTime.Now.Ticks).TotalMilliseconds;
                this.Start.Background = Brushes.White;
                this.Start.Foreground = Brushes.Black;
                
                timer.Start();

                state = 1;
            }
        }
        private void Target_Click(object sender, RoutedEventArgs e)
        {
            if (state >= 1)
            {
                timer.Stop();
                Point click = Mouse.GetPosition(Grid);
                end_time = new TimeSpan(DateTime.Now.Ticks).TotalMilliseconds;
                double t = Math.Round(end_time - start_time, 0);
                trialList[current].time = (int) t;
                trialList[current].success = state == 1 ? 1 : 0;
                this.Time.Content = "  " + t.ToString() + "ms";
                this.Time.Margin = new Thickness(click.X, click.Y - this.Time.Height / 2, 0, 0);
                
                trialList[current].cursorPos.Add(click);
                trialList[current].timePos.Add(t);

                current++;
                if (current == trialList.Count)
                {
                    //save to files
                    var directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                    using (StreamWriter outputFile = new StreamWriter(directory + @"\Part2.txt"))
                    {
                        outputFile.WriteLine("SubjectID TrialNum Amplitude Width StartPos TargetPos Time Success");
                        for (int i = 0; i < trialList.Count; i++)
                        {
                            outputFile.WriteLine(study.subject_id.Value.ToString()
                                + " " + (i + 1).ToString()
                                + " " + trialList[i].amplitude.ToString()
                                + " " + trialList[i].width.ToString()
                                + " (" + trialList[i].startPos.ToString() + ")"
                                + " (" + trialList[i].endPos.ToString() + ")"
                                + " " + trialList[i].time.ToString()
                                + " " + trialList[i].success.ToString());
                        }
                    }
                    using (StreamWriter outputFile = new StreamWriter(directory + @"\Part3.txt"))
                    {
                        outputFile.WriteLine("SubjectID TrialNum Amplitude Width StartPos TargetPos Time Success CursorPos (x, y)");
                        for (int i = 0; i < trialList.Count; i++)
                        {
                            for (int j = 0; j < trialList[i].cursorPos.Count; j++)
                            {
                                outputFile.Write(trialList[i].subjectID.ToString()
                                    + " " + (i + 1).ToString()
                                    + " " + trialList[i].amplitude.ToString()
                                    + " " + trialList[i].width.ToString()
                                    + " (" + trialList[i].startPos.ToString() + ")"
                                    + " (" + trialList[i].endPos.ToString() + ")"
                                    + " " + trialList[i].timePos[j].ToString()
                                    + " " + trialList[i].success.ToString()
                                    + " (" + trialList[i].cursorPos[j].ToString() + ")");
                                if (j == 0)
                                {
                                    outputFile.WriteLine(" ß-- cursor position when the start button is clicked.");
                                }
                                else if (j == trialList[i].cursorPos.Count - 1)
                                {
                                    outputFile.WriteLine(" ß-- cursor position when the target is clicked");
                                }
                                else
                                {
                                    outputFile.WriteLine();
                                }
                            }
                            
                        }
                    }
                    MessageBox.Show("Test completed.");
                    Application.Current.Shutdown();
                    return;
                }
                this.Time.Dispatcher.BeginInvoke(DispatcherPriority.SystemIdle, new nextTrialDelegate(test));
            }
            
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (state == 1)
            {
                state = 2;
            }
        }

        private void getCursorPos(object sender, EventArgs e)
        {
            trialList[current].cursorPos.Add(Mouse.GetPosition(Grid));
            trialList[current].timePos.Add(Math.Round(new TimeSpan(DateTime.Now.Ticks).TotalMilliseconds - start_time));
        }
        
    }
}
