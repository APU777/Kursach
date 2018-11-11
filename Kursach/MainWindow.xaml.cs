using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursach
{

    public partial class MainWindow : Window
    {
        public static byte QuantityPlayers { get; set; }
        private static float[] BigCardsArray = new float[36] { 1.1f, 1.2f, 1.3f, 1.4f, 2.1f, 2.2f, 2.3f, 2.4f, 3.1f, 3.2f, 3.3f, 3.4f, 4.1f, 4.2f, 4.3f, 4.4f, 5.1f, 5.2f, 5.3f, 5.4f, 6.1f, 6.2f, 6.3f, 6.4f, 7.1f, 7.2f, 7.3f, 7.4f, 8.1f, 8.2f, 8.3f, 8.4f, 9.1f, 9.2f, 9.3f, 9.4f };
        private static Label _BufferCards = null;
        private static int _TrumpCard = 0;
        private static Queue<float> CardsStore = new Queue<float>();
        private static Label[] PlayerCardsImage = null;
        private static List<float>[] PlayersCards = null;
        private static List<float> WarField = new List<float>();

        private void InitializePlayers()
        {
            for(int index_Child = 5; index_Child < 23; ++ index_Child)
            {
                ((Label)BigField.Children[index_Child]).Background = null;
            }

            PlayerCardsImage = new Label[6] { Card_One, Card_Two, Card_Three, Card_Four, Card_Five, Card_Six };
             
            PlayersCards = new List<float>[QuantityPlayers];

            foreach (Label PCI in PlayerCardsImage)
                PCI.Margin = new Thickness(10);
            for(int index = 0; index < QuantityPlayers; ++index)
                PlayersCards[index] = new List<float>();
        }

        public MainWindow(byte QtyPL)
        {
            QuantityPlayers = QtyPL;
            InitializeComponent();
            InitializePlayers();


            //MessageBox.Show((BigField.Children[5]).ToString());
            ((Label)BigField.Children[5]).Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Kursach;component/CardsImage/1.1.png")));
            ((Label)BigField.Children[6]).Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Kursach;component/CardsImage/2.1.png")));
            //((Label)BigField.Children[7]).Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Kursach;component/CardsImage/1.3.png")));
            //((Label)BigField.Children[8]).Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Kursach;component/CardsImage/2.2.png")));
            //((Label)BigField.Children[5]).BorderBrush = Brushes.DarkViolet;
            //((Label)BigField.Children[5]).BorderThickness = new Thickness(5);
            //((Label)BigField.Children[6]).BorderBrush = Brushes.DarkViolet;
            //((Label)BigField.Children[6]).BorderThickness = new Thickness(5);
            //((Label)BigField.Children[7]).BorderBrush = Brushes.DarkViolet;
            //((Label)BigField.Children[7]).BorderThickness = new Thickness(5);

            Logic_sAlgorithms.MixCards(ref BigCardsArray);
            Logic_sAlgorithms.LayingCardsINDeck(ref BigCardsArray, ref CardsStore);
            PlayAlgorithms.ShareOutCards(ref PlayersCards, ref CardsStore );
            _TrumpCard = PlayAlgorithms.TrumpCARD(ref LearImg, ref BigCardsArray);
            int FirstPlayer = PlayAlgorithms.CheckPlayerStep(ref PlayersCards, ref _TrumpCard);
            PlayAlgorithms.Steps(FirstPlayer, L_Pl_Field);
            MessageBox.Show(FirstPlayer.ToString());
            Logic_sAlgorithms.LookCards(ref PlayersCards[0], ref PlayerCardsImage);

        }

        private void Give_Up_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Give_Up_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void Card_One_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _BufferCards = Card_One;
            Logic_sAlgorithms.VisualAnimation(ref BigField);
        }

        private void Card_Two_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _BufferCards = Card_Two;
        }

        private void Card_Three_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _BufferCards = Card_Three;
        }

        private void Card_Four_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _BufferCards = Card_Four;
        }

        private void Card_Five_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _BufferCards = Card_Five;
        }

        private void Card_Six_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _BufferCards = Card_Six;
        }

        private void FirstBig_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void SecondBig_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ThirdBig_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void FourthBig_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void FifthBig_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void SixthBig_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AFirstLittle_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BFirstLittle_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ASecondLittle_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BSecondLittle_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AThirdLittle_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BThirdLittle_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AFourthLittle_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BFourthLittle_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AFifthLittle_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BFifthLittle_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ASixthLittle_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BSixthLittle_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
