﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Kursach
{
    static class PlayAlgorithms
    {
        public static void ShareOutCards(ref List<float>[] PlayersCards, ref Queue<float> CardsStore)
        {
            for (int index = 0; index < PlayersCards.Length; ++index)
                PlayersCards[index] = Logic_sAlgorithms.DistributeCards(ref PlayersCards[index], ref CardsStore);
        }

        public static int TrumpCARD (ref Label _LearImg, ref float[] Array)
        {
            int TC = Logic_sAlgorithms._TrumpCard();

            _LearImg.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Kursach;component/LearsImage/" + TC + ".jpg")));

            return TC;
        }

        public static int CheckPlayerStep(ref List<float>[] PlayersCards, ref int _TrumpCard)
        {
            int FIRST_PLAYER = 0;
            float _TC = 0;
            for(int indexROW = 0; indexROW < PlayersCards.Length; ++indexROW)
            {
                for(int indexCOLUMN = 0; indexCOLUMN < PlayersCards[indexROW].Count; ++indexCOLUMN)
                {
                    if (_TrumpCard == (int)PlayersCards[indexROW][indexCOLUMN] && _TC < PlayersCards[indexROW][indexCOLUMN])
                        FIRST_PLAYER = indexROW;
                }
            }
            return FIRST_PLAYER;
        }

        public static Brush Steps(Label Field, float Pl_Card, int _TrumpCard, float En_Card)
        {
            
            if (Logic_sAlgorithms.BeatCard(Pl_Card, En_Card, _TrumpCard))
            {
                Field.BorderBrush = null;
                return new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Kursach;component/CardsImage/" + Pl_Card + ".png")));
            }
            MessageBox.Show("Sorry, but you can't beat this card.");
            return null;
        }

    }
}
