namespace NumberGuesser
{
    class NumberGenerator
    {

        public int RNG = 0;
        public int Range = 100;

        public void Numbergenerating()
        {
            //auswahl der grösse des Zahlenbereiches
            Console.Write("in welcher Zahlenrange wollen sie spielen? (nur das maximum angeben) ");
            Range = Convert.ToInt32(Console.ReadLine());

            //den hier folgenden Zahlen Generator habe ich von Stack-overflow abgeschrieben.
            //hier wird die zu erratende Zahl generiert 
            Random rnd = new Random();
            RNG = rnd.Next(1, Range);
        }
    }
}
