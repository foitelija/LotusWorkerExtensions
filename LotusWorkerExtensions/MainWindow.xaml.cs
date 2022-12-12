using LotusWorkerExtensions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace LotusWorkerExtensions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IncomingMessageContext _context;

        public MainWindow(IncomingMessageContext context)
        {
            InitializeComponent();
            _context = context;
        }

        bool isWorking = false;
        int counter = 0;
        int age1 = 0;
        int age2 = 0;
        int age3 = 0;

        private async void startWorker_Click(object sender, RoutedEventArgs e)
        {
            isWorking = true;
            //List<IncomingMessage> messages = _context.incomingMessages.ToList();

            await PingCounter();
        }

        private delegate void TimeHandler();

        async Task PingCounter()
        {

            do
            {
                counter++;
                age1++;age2++;age3++;
                counterLabel.Dispatcher.Invoke(new TimeHandler(counterPrint));

                await Task.Delay(3000);
            }
            while (isWorking);
        }

        void counterPrint()
        {
            counterLabel.Content = counter.ToString();

            _context.incomingMessages.Add(new IncomingMessage
            {
                Age1 = age1,
                Age2 = age2,
                Age3 = age3,
            });
            _context.SaveChangesAsync();
        }

        private void stopWorker_Click(object sender, RoutedEventArgs e)
        {
            isWorking=false;
        }
    }
}
