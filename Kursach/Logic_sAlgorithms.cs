using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Kursach
{
    internal static class Logic_sAlgorithms
    {
        public static void MixCards(ref float[] _Array)
        {
            Random random = new Random();
            List<string> R_Arr = new List<string>();
            Queue<float> ReturnQueue = new Queue<float>();
            int CardIndex = 0;
            try
            {
                while (R_Arr.Count < _Array.Length)
                {
                    CardIndex = random.Next(0, _Array.Length);
                    if (!R_Arr.Contains(CardIndex.ToString()))
                    {
                        R_Arr.Add(CardIndex.ToString());
                        ReturnQueue.Enqueue(_Array[CardIndex]);
                    }
                }

                for(int i = 0; i < _Array.Length; ++i)
                    _Array[i] = ReturnQueue.Dequeue();
            }
            catch(Exception Exc)
            {
                MessageBox.Show(Exc.Message);
            }
        }

        public static void LayingCardsINDeck (ref float[] _Array, ref Queue<float> To_Store)
        {
            foreach (float _Arr in _Array)
                To_Store.Enqueue(_Arr);
        }

        public static int _TrumpCard()
        {
            Random random = new Random();
            return random.Next(1, 5); 
        }

        public static List<float> DistributeCards(ref List<float> Pl_Cards, ref Queue<float> CardsStore)
        {
           while(Pl_Cards.Count < 6)
                Pl_Cards.Add(CardsStore.Dequeue());

           return Pl_Cards.OrderBy(OBfMnToMx => OBfMnToMx).ToList();
        }

        public static void LookCards(ref List<float> Pl_Cards, ref Label[] Pl_CardsImage)
        {
            for (int index = 0; index < Pl_CardsImage.Length; ++index)
            {
                Pl_CardsImage[index].Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Kursach;component/CardsImage/"+ Pl_Cards[index] +".png")));
            }
        }

        public static bool BeatCard(float _Card, float _EnemyCard ,int _TrumpCard)
        {
            if (_Card > _EnemyCard || (int)_Card == _TrumpCard && (int)_Card != (int)_EnemyCard)
                return true;
            else
                return false;
        }

    }
}
