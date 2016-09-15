using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sample_mouse_movement_simulate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        [DllImport("User32.dll")]
       private static extern bool SetCursorPos(int X, int Y);

        static int coordX;
        static int coordY = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void moveMS_Click(object sender, RoutedEventArgs e)
        {
          
            //if ((main.Width >= coordX) && (main.Height >= coordY))
            //{
                SetCursor(Convert.ToInt16(positionX.Text), Convert.ToInt16(positionY.Text));
            //}
            //else
            //{
            //    status.Content = "Out of Window";
            //}
                   
        }

        private static void SetCursor(int x, int y)
        {
            // Left boundary
            var xL = (int)App.Current.MainWindow.Left + 8;
            // Top boundary
            var yT = (int)App.Current.MainWindow.Top + 31;
            coordX = x + xL;
            coordY = y + yT;

            SetCursorPos(x + xL, y + yT);
        }

        private void main_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            status.Content = "X: " + e.GetPosition(main).X + " Y: " + e.GetPosition(main).Y;
        }
    }
}
