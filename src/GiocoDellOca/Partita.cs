using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace GiocoDellOca
{
    public class Partita
    {

        private Dictionary<string, int> segnalini;

        public Partita()
        {
            segnalini = new Dictionary<string, int>();
        }

        public void AggiungiGiocatore(string nomeGiocatore)
        {
            if (segnalini.ContainsKey(nomeGiocatore))
                throw new ArgumentException(String.Format("{0}: Giocatore già Presente", nomeGiocatore));
            segnalini.Add(nomeGiocatore, 0);
        }

        public string DammiGiocatori()
        {
            return string.Concat("Giocatori: ", string.Join(", ", segnalini.Keys));
        }

        public string MuoviSegnalino(string nomeGiocatore, int dadoUno, int dadoDue)
        {
            var segnalino_originale = segnalini[nomeGiocatore];
            segnalini[nomeGiocatore] += dadoUno + dadoDue;

            return string.Format("{0} tira {1}, {2}. {0} muove da {4} a {3}{5}", 
                nomeGiocatore, 
                dadoUno, 
                dadoDue, 
                segnalini[nomeGiocatore], 
                OttieniPosizione(segnalino_originale), 
                HaVinto(nomeGiocatore) ? ". Pippo vince!!" : "");
        }

        private bool HaVinto(string nomeGiocatore)
        {
            return segnalini[nomeGiocatore] == 63;
        }

        private static string OttieniPosizione(int segnalino_originale)
        {
            return segnalino_originale == 0 ? "Partenza" : segnalino_originale.ToString();
        }
    }
}
