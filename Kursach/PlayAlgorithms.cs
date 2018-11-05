using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    static class PlayAlgorithms
    {
        public static void ShareOutCards(ref List<float>[] PlayersCards, ref Queue<float> CardsStore)
        {
            for (int index = 0; index < PlayersCards.Length; ++index)
                PlayersCards[index] = Logic_sAlgorithms.DistributeCards(ref PlayersCards[index], ref CardsStore);
        }
    }
}
