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
        public static List<float> Variable = new List<float>();
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

                for (int i = 0; i < _Array.Length; ++i)
                    _Array[i] = ReturnQueue.Dequeue();
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.Message);
            }
        }

        public static void LayingCardsINDeck(ref float[] _Array, ref Queue<float> To_Store)
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
            while (Pl_Cards.Count < 6)
                Pl_Cards.Add(CardsStore.Dequeue());

            return Pl_Cards.OrderBy(OBfMnToMx => OBfMnToMx).ToList();
        }

        public static void LookCards(ref List<float> Pl_Cards, ref Label[] Pl_CardsImage)
        {
            Pl_Cards = Pl_Cards.OrderBy(OBfMnToMx => OBfMnToMx).ToList();
            for (int index = 0; index < Pl_CardsImage.Length; ++index)
            {
                if (index < Pl_Cards.Count)
                {
                    Pl_CardsImage[index].Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Kursach;component/CardsImage/" + Pl_Cards[index] + ".png")));
                }
                else
                {
                    Pl_CardsImage[index].Background = null;
                    Pl_CardsImage[index].BorderThickness = new Thickness(1);
                }
            }
        }

        public static bool BeatCard(float _Card, float _EnemyCard, int _TrumpCard)
        {
            int Cd = int.Parse(_Card.ToString().ElementAt(2).ToString());
            int ECd = int.Parse(_EnemyCard.ToString().ElementAt(2).ToString());

            if (_Card > _EnemyCard && Cd == ECd)
                return true;
            else if (Cd == _TrumpCard && _Card > _EnemyCard)
                return true;
            else if (Cd == _TrumpCard && Cd != ECd)
                return true;
            else
                return false;
        }

        public static void BBeated(ref List <float> LiF, ref Grid BigField)
        {
            for(int index = 5; index < 23; ++index)
            {
                ((Label)BigField.Children[index]).Background = null;
            }
            LiF.Clear();
        }

        public static void VisualAnimation(ref Grid BigField)
        {
            bool Check = true;

            if (((Label)BigField.Children[10]).Background != null)
                Check = false;

           if(Check)
            {
                for(int index = 5; index < 11; index+=2)
                {
                    if (((Label)BigField.Children[index]).Background == null)
                    {
                        ((Label)BigField.Children[index]).BorderBrush = Brushes.White;
                        ((Label)BigField.Children[index]).BorderThickness = new Thickness(7);
                        break;
                    }
                }
            }
           else
            {
                for (int index = 11; index < 23; index += 2)
                {
                    if (((Label)BigField.Children[index]).Background == null)
                    {
                        ((Label)BigField.Children[index]).BorderBrush = Brushes.White;
                        ((Label)BigField.Children[index]).BorderThickness = new Thickness(7);
                        break;
                    }
                }
            }
        }
    }
}
