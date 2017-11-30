using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Model.classes;

namespace Estimates
{
    /// <summary>
    /// Interaction logic for UserControlDiagram.xaml
    /// </summary>
    public partial class UserControlDiagram : UserControl
    {
        Random rnd = new Random();

        public UserControlDiagram()
        {
            InitializeComponent();

        }
        public UserControlDiagram(Contract contract)
        {
            InitializeComponent();
            if (contract.Building.Count!=0)
            {
                int number = contract.Building.Count();
                float sum = 0;
                foreach (Building bld in contract.Building)
                {
                    sum += bld.CostOfTheObject;
                }

                SolidColorBrush selectedColor = new SolidColorBrush();
                StackPanel mainPanel = new StackPanel();
                mainPanel.Orientation = Orientation.Vertical;
                DockPanel grapghPanel = new DockPanel();
                DockPanel.SetDock(grapghPanel, Dock.Left);

                StackPanel legendPanel = new StackPanel();
                Thickness th = legendPanel.Margin;
                th.Left = 10;
                legendPanel.Margin = th;

                legendPanel.Orientation = Orientation.Vertical;
                Label graphHeadLabel = new Label();
                Label legendHeadLabel = new Label();
                graphHeadLabel.FontSize = 22;
                graphHeadLabel.Content = "Диаграмма распределения выручки по объектам";
                legendHeadLabel.Content = sum.ToString("0.0") + "тыс.р. - сумма по контракту №  " + contract.ContractNumber;

                foreach (Building building in contract.Building)
                {
                    selectedColor = GetSolidBrush();
                    StackPanel stackInGraph = new StackPanel();

                    stackInGraph.HorizontalAlignment = HorizontalAlignment.Left;
                    Label labelInGraph = new Label();
                    Label labelLegendName = new Label();
                    Label labelLegendCost = new Label();
                    Rectangle rectGraph = new Rectangle();
                    Rectangle rectLegend = new Rectangle();
                    StackPanel stackInLegend = new StackPanel();
                    stackInLegend.Orientation = Orientation.Horizontal;

                    rectGraph.Height = 30;
                    rectGraph.Width = building.CostOfTheObject / sum * 400;
                    rectGraph.Fill = selectedColor;
                    labelInGraph.FontSize = 10;
                    labelInGraph.Content = (building.CostOfTheObject / sum * 100).ToString("0.0") + "%";
                    stackInGraph.Children.Add(labelInGraph);
                    stackInGraph.Children.Add(rectGraph);

                    labelLegendName.Content = building.NameOfTheObject;
                    rectLegend.Fill = selectedColor;
                    rectLegend.Height = 15;
                    rectLegend.Width = 15;
                    labelLegendCost.Content = building.CostOfTheObject.ToString("0.0") + "тыс.р - ";

                    stackInLegend.Children.Add(rectLegend);
                    stackInLegend.Children.Add(labelLegendCost);
                    stackInLegend.Children.Add(labelLegendName);
                    legendPanel.Children.Add(stackInLegend);
                    grapghPanel.Children.Add(stackInGraph);

                }
                mainPanel.Children.Add(graphHeadLabel);
                mainPanel.Children.Add(grapghPanel);
                mainPanel.Children.Add(legendHeadLabel);
                mainPanel.Children.Add(legendPanel);
                this.Content = mainPanel; 
            }
            else
            {
                Label graphHeadLabel = new Label();
                graphHeadLabel.Content = "В договоре отсутствуют объекты";
                this.Content = graphHeadLabel;
            }
        }
        public SolidColorBrush GetSolidBrush()
        {
            SolidColorBrush newSolidColorBrush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255)));
            return newSolidColorBrush;
        }
    }
}
