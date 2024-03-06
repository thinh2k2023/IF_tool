﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WPFiftool.ViewModels.SignalMonitor;
using static WPFiftool.Models.Common_string;
using WPFiftool.Models.ConfigSignal;
using WPFiftool.ViewModels.ConfigSignalVM;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WPFiftool.Models;
using ControlzEx.Standard;

namespace WPFiftool.Views
{
    /// <summary>
    /// Interaction logic for ConfigSignalWindow.xaml
    /// </summary>
    public partial class ConfigSignalWindow : Window
    {
        // declearate some variable for onpen window one time
        const Int16 OFF = 0;
        const Int16 ON = 1;

        public ConfigSignalWindow()
        {
            InitializeComponent();
            SigmntDG.ItemsSource = ConfigSignalHandle.SignalMonitorConfigData;
        }

        //InputMonitor.SignalMonitorDataSave
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputMonitor.SignalMonitorDataSave.Clear();
            InputMonitor.SignalMonitorDataSaveExcel.Clear();
            foreach (ConfigSignalModel signal in ConfigSignalHandle.SignalMonitorConfigData)
            {
                string typeValue = signal.Type;
                string Channel = signal.Channel;
                string IO = signal.IO;
                string SignalName = signal.SignalName;
                string Element = signal.Element;
                string Value = signal.Value;
                string Unit = signal.Unit;
                string MinLabel = signal.MinLabel;
                string MaxLabel = signal.MaxLabel;
                string Resolution = signal.Resolution;
                string Offset = signal.Offset;

                string VisibleInput;

                if (signal.IsVisible == true)
                {
                    VisibleInput = "Yes";
                }
                else
                {
                    VisibleInput = "No";
                }
                string OrderMonitor = signal.OrderMonitor;
                string VisibleOutput = signal.VisibleOutput;
                string OrderOutput = signal.OrderOutput;

                InputMonitor.SignalMonitorDataSave.Add(new Signal_Title()
                {
                    Type = typeValue,
                    Channel = Channel,
                    IO = IO,
                    SignalName = SignalName,
                    Element = Element,
                    Value = Value,
                    Unit = Unit,
                    MinLabel = MinLabel,
                    MaxLabel = MaxLabel,
                    Resolution = Resolution,
                    Offset = Offset,
                    VisibleMonitor = VisibleInput,
                    OrderMonitor = OrderMonitor,
                    VisibleOutput = VisibleOutput,
                    OrderOutput = OrderOutput
                });

                InputMonitor.SignalMonitorDataSaveExcel.Add(new Signal_Title()
                {
                    Type = typeValue,
                    Channel = Channel,
                    IO = IO,
                    SignalName = signal.SignalName.Substring(0, signal.SignalName.Length - signal.Element.Length),
                    Element = Element,
                    Value = Value,
                    Unit = Unit,
                    MinLabel = MinLabel,
                    MaxLabel = MaxLabel,
                    Resolution = Resolution,
                    Offset = Offset,
                    VisibleMonitor = VisibleInput,
                    OrderMonitor = OrderMonitor,
                    VisibleOutput = VisibleOutput,
                    OrderOutput = OrderOutput
                });

            }





            InputMonitor.FilterData();
        }

        private void StartUpProgramLoaded(object sender, RoutedEventArgs e)
        {
            DataConversion.ShowConfigSignalWindow = ON;
        }

        private void CloseProgramUnloaded(object sender, RoutedEventArgs e)
        {
            DataConversion.ShowConfigSignalWindow = OFF;
        }
    }
}
