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
        private static byte QuantityPlayers = 2;
        private static float[] BigCardsArray = new float[36] { 1.1f, 1.2f, 1.3f, 1.4f, 2.1f, 2.2f, 2.3f, 2.4f, 3.1f, 3.2f, 3.3f, 3.4f, 4.1f, 4.2f, 4.3f, 4.4f, 5.1f, 5.2f, 5.3f, 5.4f, 6.1f, 6.2f, 6.3f, 6.4f, 7.1f, 7.2f, 7.3f, 7.4f, 8.1f, 8.2f, 8.3f, 8.4f, 9.1f, 9.2f, 9.3f, 9.4f };
        private static Queue<float> CardsStore = new Queue<float>();
        private static Label[] PlayerCardsImage = null;
        private static List<float>[] PlayersCards = new List<float>[4];

        private void InitializePlayers()
        {
            PlayerCardsImage = new Label[6] { Card_One, Card_Two, Card_Three, Card_Four, Card_Five, Card_Six };

            for(int index = 0; index < QuantityPlayers; ++index)
                PlayersCards[index] = new List<float>();

        }
        public MainWindow()
        {
            InitializeComponent();
            InitializePlayers();
            Logic_sAlgorithms.MixCards(ref BigCardsArray);
            Logic_sAlgorithms.LayingCards(ref BigCardsArray, ref CardsStore);
            MessageBox.Show(CardsStore.Count.ToString());
            PlayersCards[0] = Logic_sAlgorithms.DistributeCards(ref PlayersCards[0], ref CardsStore);
            Logic_sAlgorithms.LookCards(ref PlayersCards[0], ref PlayerCardsImage);

            MessageBox.Show(CardsStore.Count.ToString());

        }
    }
}
