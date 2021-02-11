using System;
using System.Collections.Generic;
using System.Text;

using Lancer = Pair<int, bool>;

public class DiceLauncher
{
    public static Lancer LancerDes()
    {
        Random r = new Random();
        int dice1 = r.Next(1, 7);
        int dice2 = r.Next(1, 7);
        return new Lancer(dice1 + dice2, dice1 == dice2);
    }
}




