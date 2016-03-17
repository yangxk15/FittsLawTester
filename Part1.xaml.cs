using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
    /// Interaction logic for Part1.xaml
    /// </summary>
    
    public class Study
    {
        public int? subject_id { get; set; }
        public int? trials_per_condition { get; set; }
        public ObservableCollection<int> amplitudes_list;
        public ObservableCollection<int> widths_list;
        public ObservableCollection<double> indices_of_difficulty_list;
        public Study()
        {
            amplitudes_list = new ObservableCollection<int>();
            widths_list = new ObservableCollection<int>();
            indices_of_difficulty_list = new ObservableCollection<double>();
        }
    }
    public partial class Part1 : Page
    {
        Study study;
        public Part1()
        {
            InitializeComponent();
            study = new Study();
            this.Amplitudes_List.ItemsSource = study.amplitudes_list;
            this.Widths_List.ItemsSource = study.widths_list;
            this.Indices_of_Difficulty_List.ItemsSource = study.indices_of_difficulty_list;
            this.A_add.IsEnabled = false;
            this.W_add.IsEnabled = false;
            this.A_delete.IsEnabled = false;
            this.W_delete.IsEnabled = false;
            this.OK.IsEnabled = false;
        }

        private bool isOK()
        {
            return study.subject_id != null && study.trials_per_condition != null && study.amplitudes_list.Count > 0 && study.widths_list.Count > 0;
        }

        private void SubjectID_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            study.subject_id = this.SubjectID.Value;
            this.OK.IsEnabled = isOK();
        }

        private void Trials_Per_Condition_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            study.trials_per_condition = this.Trials_Per_Condition.Value;
            if (study.trials_per_condition != null)
                UpdateTotalTrials();
            this.OK.IsEnabled = isOK();
        }

        private void Amplitudes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.A_add.IsEnabled = this.Amplitudes.Value != null ? true : false;
        }

        private void Widths_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.W_add.IsEnabled = this.Amplitudes.Value != null ? true : false;
        }

        private void A_add_Click(object sender, RoutedEventArgs e)
        {
            if (!study.amplitudes_list.Contains(this.Amplitudes.Value.Value))
            {
                study.amplitudes_list.Add(this.Amplitudes.Value.Value);
                UpdateList();
            }
            this.OK.IsEnabled = isOK();
        }

        private void W_add_Click(object sender, RoutedEventArgs e)
        {
            if (!study.widths_list.Contains(this.Widths.Value.Value))
            {
                study.widths_list.Add(this.Widths.Value.Value);
                UpdateList();
            }
            this.OK.IsEnabled = isOK();
        }

        private void A_delete_Click(object sender, RoutedEventArgs e)
        {
            study.amplitudes_list.RemoveAt(this.Amplitudes_List.SelectedIndex);
            this.A_delete.IsEnabled = false;
            UpdateList();
            this.OK.IsEnabled = isOK();
        }

        private void W_delete_Click(object sender, RoutedEventArgs e)
        {
            study.widths_list.RemoveAt(this.Widths_List.SelectedIndex);
            this.W_delete.IsEnabled = false;
            UpdateList();
            this.OK.IsEnabled = isOK();
        }

        private void Amplitudes_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.A_delete.IsEnabled = true;
        }

        private void Widths_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.W_delete.IsEnabled = true;
        }


        private void UpdateTotalTrials()
        {
            int total = (study.trials_per_condition == null ? 0 : study.trials_per_condition.Value) * study.amplitudes_list.Count * study.widths_list.Count;
            this.Total_Trials.Content = "Total trials: " + total.ToString();
        }

        private void UpdateList()
        {
            UpdateTotalTrials();
            study.indices_of_difficulty_list.Clear();
            HashSet<double> set = new HashSet<double>();
            foreach (var i in study.amplitudes_list)
            {
                foreach (var j in study.widths_list)
                {
                    double value = 2 * i / j;
                    if (!set.Contains(value))
                    {
                        set.Add(value);
                        study.indices_of_difficulty_list.Add(Math.Round(Math.Log(value) / Math.Log(2), 2));
                    }
                }
            }
            this.uniCount.Content = "(" + study.indices_of_difficulty_list.Count + " unique)";
            bubbleSort(study.amplitudes_list);
            bubbleSort(study.widths_list);
            bubbleSort(study.indices_of_difficulty_list);
        }

        private void bubbleSort<T>(ObservableCollection<T> list) where T : IComparable
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (list[j].CompareTo(list[j + 1]) >= 0)
                    {
                        T temp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Part1_Study ps = new Part1_Study(study);
            this.NavigationService.Navigate(ps);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        
    }
        
}
