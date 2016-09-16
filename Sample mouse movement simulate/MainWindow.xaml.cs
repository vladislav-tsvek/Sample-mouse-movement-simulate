using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

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
        static int coordY;

        static int baseX;
        static int baseY;

        int tempX;
        int tempY;

        System.Windows.Forms.Timer myTimer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void moveMS_Click(object sender, RoutedEventArgs e1)
        {
            baseX = (int)Mouse.GetPosition(main).X;
            baseY = (int)Mouse.GetPosition(main).Y;

            coordX = Convert.ToInt16(positionX.Text);
            coordY = Convert.ToInt16(positionY.Text);
            
            tempX = baseX;
            tempY = baseY;
            
            myTimer = new System.Windows.Forms.Timer();
            myTimer.Interval = 10;
            myTimer.Tick += MyTimer_Tick;
           
            myTimer.Start();           
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {

            if (coordX > tempX)
                tempX = tempX + 1;
            else if (coordX == tempX){}
            else
                tempX = tempX - 1;


            if (coordY > tempY)
                tempY = tempY + 1;
            else if (coordY == tempY) {}
            else
                tempY = tempY - 1;

            if ((coordX == tempX) && (coordY == tempY))
            {
                myTimer.Stop();
                status.Content = "Done!";
            }
            else
            {
                SetCursor(tempX, tempY);
            }
        }

        private static void SetCursor(int x, int y)
        {
            try
            {
                // Left boundary
                var xL = (int)App.Current.MainWindow.Left + 8;
                // Top boundary
                var yT = (int)App.Current.MainWindow.Top + 31;
                //coordX = x + xL;
                //coordY = y + yT;

                SetCursorPos(x + xL, y + yT);
            }
           
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
        }

        private void main_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {            
            status.Content = "X: " + e.GetPosition(main).X + " Y: " + e.GetPosition(main).Y;
        }                
    }
 }
