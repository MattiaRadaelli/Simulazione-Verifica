using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulazione_Verifica
{
        class Persona
        {
            protected string nome;
            public string Nome
            {
                get { return nome; }
                set
                {
                    if (value.Length >= 2)
                    {
                        nome = value;
                    }
                    else
                    {
                        nome = "Non Validus";
                    }
                }
            }
        protected string provincia;
        public string Provincia
        {
            get { return provincia; }
            set
            {
                if (value.Length >= 2)
                {
                    provincia = value;
                }
                else
                {
                    provincia = "Mancante";
                }
            }
        }
            public Persona()
            {
                nome = "Sconosciuto";
                provincia = "Sconosciuta";
            }
        }

        class Conto : Persona
        {
            private float euro;
            private bool chiu;
            public float Euro
            {
                get { return euro; }
                set { euro = value; }
            }
            public bool Chiu
            {
                get { return chiu; }
                set { chiu = value; }
            }
            public Conto()
            {
                chiu = true;
                euro = 0;
            }
            public void apri()
            {
                chiu = false;
            }
            public void deposita(float cifra)
            {
                euro += cifra;
            }
            public void preleva(float cifra)
            {
                euro -= cifra;
            }
            public float saldo()
            {
                return euro;
            }
            public void chiusura()
            {
                chiu = true;
            }
            public bool chiuso()
            {
                return chiu;
            }
            public void get_info()
            {
                string stato;
                if (chiu == true)
                {
                    stato = "Chiuso";
                }
                else
                {
                    stato = "Aperto";
                }
                Console.WriteLine($"Nome Conto : {nome} \nProvincia Utente : {provincia} \nSaldo Conto : {euro} euro \nStato Conto : {stato} \n");
                Console.ReadLine();
            }
        }

    class Banca
    {
        List<Conto> conti = new List<Conto>();
        public Banca()
        {
            for (int i = 0; i < 100; i++)
            {
                conti.Add(new Conto());
            }
        } 
            int i = 0;

            public void Scegli()
            {
                Console.WriteLine("Inserisci il conto da gestire:");
                i = int.Parse(Console.ReadLine());
            }
            public void ApriConto()
            {
                conti[i] = new Conto();
                conti[i].apri();
                Console.WriteLine("Inserisci nome utente:");
                conti[i].Nome = Console.ReadLine();
                Console.WriteLine("Inserisci provincia utente:");
                conti[i].Provincia = Console.ReadLine();
            }
            public void ChiudiConto()
            {
                conti[i].chiusura();
            }
            public void DepositaSuConto()
            {
                Console.WriteLine("Quanto vuoi depositare sul conto?");
                conti[i].deposita(float.Parse(Console.ReadLine()));
            }
            public void PrelevaDaConto()
            {
                Console.WriteLine("Quanto vuoi prelevare dal conto?");
                conti[i].preleva(float.Parse(Console.ReadLine()));
            }
            public void VediSaldoConto()
            {
                Console.WriteLine($"il tuo saldo è di {conti[i].saldo()} euro");
                Console.ReadLine();
            }
            public void VediInfoConto()
            {
                conti[i].get_info();
            }
        public void ContaUtentiProv()
        {
            Console.WriteLine("Di quale provincia vuoi sapere il N di utenti?");
            string provincia = Console.ReadLine();
            int contatore = 0;           
            for (int i = 0; i < 100; i++) 
            {
               if (conti[i].Provincia == provincia)
               {
                    contatore++;
               }
            }
            Console.WriteLine($"Gli utenti a {provincia} sono {contatore}");
            Console.ReadLine();
        }
        public void SommaSaldoUtentiProv()
        {
            Console.WriteLine("Di quale provincia vuoi sapere il saldo totale di utenti?");
            string provincia = Console.ReadLine();
            float somma = 0;
            for (int i = 0; i < 100; i++)
            {
                if (conti[i].Provincia == provincia)
                {
                    somma += conti[i].Euro;
                }
            }
            Console.WriteLine($"Il saldo totale deli utenti a {provincia} è di {somma} euro");
            Console.ReadLine();
        }
    }

        internal class Program
        {
            static void Main(string[] args)
            {
                Banca b = new Banca();
                bool uscita = false;

                while (uscita == false)
                {
                    Console.Clear();
                    Console.WriteLine("1) Apri il conto");
                    Console.WriteLine("2) Chiudi il conto");
                    Console.WriteLine("3) Deposita sul conto");
                    Console.WriteLine("4) Preleva dal conto");
                    Console.WriteLine("5) Vedi saldo sul conto");
                    Console.WriteLine("6) Visualizza info conto");
                    Console.WriteLine("7) Quale conto vuoi gestire");
                    Console.WriteLine("8) Quanti utenti per provincia");
                    Console.WriteLine("9) Saldo totale per utenti della provincia");
                    Console.WriteLine("*) Esci");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            b.ApriConto();
                            break;

                        case "2":
                            b.ChiudiConto();
                            break;

                        case "3":
                            b.DepositaSuConto();
                            break;

                        case "4":
                            b.PrelevaDaConto();
                            break;

                        case "5":
                            b.VediSaldoConto();
                            break;

                        case "6":
                            b.VediInfoConto();
                            break;

                        case "7":
                            b.Scegli();
                            break;

                        case "8":
                            b.ContaUtentiProv();
                            break;

                        case "9":
                            b.SommaSaldoUtentiProv();
                             break;

                    default:
                            uscita = true;
                            break;
                    }
                }
            }
        }    
    }
