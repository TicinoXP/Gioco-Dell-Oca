using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace GiocoDellOca.Test
{
    public class PartitaTest
    {
        [Test]
        public void se_aggiungo_pippo_a_nuova_partita_risponde_giocatori_pippo()
        {
            var sut = new Partita();
            sut.AggiungiGiocatore("Pippo");
            var result = sut.DammiGiocatori();
            result.Should().Be("Giocatori: Pippo");
        }

        [Test]
        public void utente_aggiunge_giocatori()
        {
            var sut = new Partita();
            sut.AggiungiGiocatore("Pippo");
            sut.AggiungiGiocatore("Pluto");
            var result = sut.DammiGiocatori();
            result.Should().Be("Giocatori: Pippo, Pluto");
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void non_possibile_aggiungere_giocatore_duplicato()
        {
            var sut = new Partita();
            sut.AggiungiGiocatore("Pippo");
            sut.AggiungiGiocatore("Pippo");

        }
        [Test]
        public void muovere_i_segnalini()
        {
            var sut = new Partita();
            sut.AggiungiGiocatore("Pippo");
            sut.AggiungiGiocatore("Pluto");

            sut.MuoviSegnalino("Pippo", 4, 2).Should().Be("Pippo tira 4, 2. Pippo muove da Partenza a 6");
            sut.MuoviSegnalino("Pluto", 2, 2).Should().Be("Pluto tira 2, 2. Pluto muove da Partenza a 4");
            sut.MuoviSegnalino("Pippo", 2, 3).Should().Be("Pippo tira 2, 3. Pippo muove da 6 a 11");

        }
        [Test]
        public void vittoria_del_giocatore()
        {
            var sut = new Partita();
            sut.AggiungiGiocatore("Pippo");
            sut.MuoviSegnalino("Pippo", 30, 30);

            sut.MuoviSegnalino("Pippo", 1, 2).Should().Be("Pippo tira 1, 2. Pippo muove da 60 a 63. Pippo vince!!");

        }
    }
}
