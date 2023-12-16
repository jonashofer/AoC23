using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC23.Days
{
    public class Day16 : DayBase
    {
        public override ValueTask<string> Solve_1()
        {
            return new ValueTask<string>(WiviuSiErlüüchtet(new Punkt(-1, 0), Richtig.GägRächts).ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            var läng = Chartä.GetLength(0);
            var höch = Chartä.GetLength(1);
            var maximum = 0;

            for (int ix = 0; ix < läng; ix++)
            {
                var soviu = WiviuSiErlüüchtet(new Punkt(ix, -1), Richtig.VoObä);
                var oderSoviu = WiviuSiErlüüchtet(new Punkt(ix, höch), Richtig.VoUngä);
                maximum = Math.Max(maximum, Math.Max(soviu, oderSoviu));
            }

            for (int üpsilon = 0; üpsilon < höch; üpsilon++)
            {
                var soviu = WiviuSiErlüüchtet(new Punkt(-1, üpsilon), Richtig.GägRächts);
                var oderSoviu = WiviuSiErlüüchtet(new Punkt(höch, üpsilon), Richtig.GägLinks);
                maximum = Math.Max(maximum, Math.Max(soviu, oderSoviu));
            }
            return new ValueTask<string>(maximum.ToString());
        }

        private int WiviuSiErlüüchtet(Punkt start, Richtig voWo)
        {
            var swisstopo = Chartä;

            var hirni = new HashSet<(Punkt Hiä, Richtig VoDereSittä)>();
            var kukschdu = new Stack<(Punkt Hiä, Richtig VoDereSittä)>([(start, voWo)]);

            while (kukschdu.TryPop(out var wo))
            {
                if (!hirni.Add(wo)) continue;

                var richtig = wo.VoDereSittä;

                var nächscht = wo.Hiä.Eis(richtig);

                if (!nächscht.BiniNoIiheimisch(swisstopo)) continue;

                switch (swisstopo[nächscht.Ix, nächscht.Üpsilon])
                {
                    case '|' when richtig is Richtig.VoLinks or Richtig.VoRächts:
                        kukschdu.Push((nächscht, Richtig.GägAbä));
                        kukschdu.Push((nächscht, Richtig.GägUfä));
                        break;
                    case '-' when richtig is Richtig.VoUngä or Richtig.VoObä:
                        kukschdu.Push((nächscht, Richtig.GägLinks));
                        kukschdu.Push((nächscht, Richtig.GägRächts));
                        break;
                    case '/':
                        var witer = richtig switch
                        {
                            Richtig.VoObä => Richtig.GägLinks,
                            Richtig.VoUngä => Richtig.GägRächts,
                            Richtig.VoRächts => Richtig.GägAbä,
                            Richtig.VoLinks => Richtig.GägUfä
                        };
                        kukschdu.Push((nächscht, witer));
                        break;
                    case '\\':
                        var witerr = richtig switch
                        {
                            Richtig.VoObä => Richtig.GägRächts,
                            Richtig.VoLinks => Richtig.GägAbä,
                            Richtig.VoUngä => Richtig.GägLinks,
                            Richtig.VoRächts => Richtig.GägUfä
                        };
                        kukschdu.Push((nächscht, witerr));
                        break;

                    case '.':
                    case '-':
                    case '|':
                        kukschdu.Push((nächscht, wo.VoDereSittä));
                        break;
                }
            }
            var erlüüchtet = hirni.Select(n => n.Hiä).Distinct().Count() - 1;
            return erlüüchtet;
        }
    }

    public record Punkt(int Ix, int Üpsilon)
    {
        public Punkt Drüber => new (Ix, Üpsilon - 1);
        public Punkt Drunger => new (Ix, Üpsilon + 1);
        public Punkt Links => new (Ix - 1, Üpsilon);
        public Punkt Rächts => new (Ix + 1, Üpsilon);

        public Punkt Eis(Richtig richtig) => richtig switch
        {
            Richtig.GägRächts => Rächts,
            Richtig.GägLinks => Links,
            Richtig.GägAbä => Drunger,
            Richtig.GägUfä => Drüber,
            _ => this
        };

        public bool BiniNoIiheimisch(char[,] chartä) 
        {
            return Ix >= 0 &&
                Üpsilon >= 0 &&
                Ix + 1 <= chartä.GetLength(0) &&
                Üpsilon + 1 <= chartä.GetLength(1);
        }
    }

    public enum Richtig
    {
        VoUngä = 1,
        GägUfä = VoUngä,
        VoObä = 2,
        GägAbä = VoObä,
        VoRächts = 3,
        GägLinks = VoRächts,
        VoLinks = 4,
        GägRächts = VoLinks
    }
}
