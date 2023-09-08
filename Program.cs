namespace NumberGuesser
{
    internal class Program
    {

        static void Main(string[] args)
        {
            NumberGenerator numberGenerator = new NumberGenerator();

            //Initieren der Variabeln für die 2 folgenden Funktionen
            bool neustart = true;
            List<int> highscores = new List<int>();

            //Funktion zur darstellung deiner Highscores während einer Session

            void DisplayHighscores()
            {
                highscores.Sort();
                Console.WriteLine("---- Highscores ----");
                for (int i = 0; i < highscores.Count && i < 10; i++)
                {
                    Console.WriteLine("Rank " + (i + 1) + ": " + highscores[i] + " guesses");
                }
            }

            //Funktion für den Neustart

            void neustartfrage()
            {
                try
                {
                    Console.WriteLine("Wollen sie nochmal spielen? [true/false] ");
                    neustart = Convert.ToBoolean(Console.ReadLine());
                    if (neustart == true)
                    {
                        Console.Clear();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Falsche eingabe, geben sie bitte true oder false ein.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }

            //while schlaufe für den restart

            while (neustart == true)
            {
                //Initieren von weiteren Genutzten Variabeln
                int Versuche = 0;
                bool Variable = false;
                Console.ForegroundColor = ConsoleColor.Cyan;

                while (Variable == false)
                {

                    try
                    {
                        if (Versuche == 0)
                        {
                            numberGenerator.Numbergenerating();
                        }

                        Console.Clear();

                        //Erste Eingabe einer Zahl
                        Console.WriteLine("geben sie bitte eine Zahl zwischen 1 und {0}", numberGenerator.Range);
                        int Zahleingabe = System.Convert.ToInt32(Console.ReadLine());



                        //erhöhen der "Versuche" Variable für den Highscore tracker, erstellen eines failsafes
                        Versuche++;

                        bool Error = false;

                        while (Error == false)
                        {
                            try
                            {

                                //if Funktion zur Kontrolle ob Zahl in richtiger Grösse ist
                                if (Zahleingabe >= 1 && Zahleingabe <= (numberGenerator.Range))
                                {
                                    //Schlaufe für eingaben
                                    while (Zahleingabe != numberGenerator.RNG)
                                    {
                                        //if schlaufen zur Kontrolle ob Zahl grösser, kleiner oder richtig ist
                                        if (Zahleingabe > numberGenerator.RNG)
                                        {
                                            Console.WriteLine("Ihre Zahl ist zu gross");
                                            Console.WriteLine("Sie haben schon {0} mal geraten", Versuche);
                                            Console.WriteLine("------------------------------------------------------------------------");
                                            Variable = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ihre Zahl ist zu klein");
                                            Console.WriteLine("Sie haben schon {0} mal geraten", Versuche);
                                            Console.WriteLine("------------------------------------------------------------------------");
                                            Variable = true;
                                        }

                                        Console.Write("geben sie bitte noch eine Zahl ein: ");
                                        Zahleingabe = Convert.ToInt32(Console.ReadLine());

                                        //erhöhung der Versuche
                                        Versuche++;
                                    }
                                    if (Zahleingabe == numberGenerator.RNG)
                                    {
                                        //Display des Endscreens
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;

                                        //display aller relevanten Daten
                                        Console.WriteLine("------------------------------------------------------------------------");
                                        Console.WriteLine("Glückwunsch sie habe die richtige Zahl erraten!");
                                        Console.WriteLine("Die richtige Nummer war: {0}", numberGenerator.RNG);
                                        Console.WriteLine("Sie haben {0} mal geraten", Versuche);
                                        Console.WriteLine("------------------------------------------------------------------------");

                                        //Aufrufen der Highscore-Funktion
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        highscores.Add(Versuche);
                                        DisplayHighscores();

                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("------------------------------------------------------------------------");

                                        //ändern der Variabeln für das Fragen über den Neustart.
                                        Variable = true;
                                        Error = true;
                                        neustart = false;

                                    }

                                }
                                else
                                {
                                    throw new Exception();

                                }
                            }
                            catch
                            {
                                //Error-Ausgabe
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Falsche eingabe, geben sie bitte eine korrekte Zahl ein");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                //Error auf false für restart der Fragen-Schlaufe
                                Error = false;
                            }

                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Falsche eingabe, geben sie bitte eine korrekte Zahl ein");
                        Console.ForegroundColor = ConsoleColor.Cyan;

                    }
                }
                //Aufrufen der neustart-Funktion
                neustartfrage();
            }
        }
    }
}
