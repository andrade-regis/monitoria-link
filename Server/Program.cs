namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Iniciar();

                Console.ReadKey();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

        private static void Iniciar()
        {
            Servidor server = new Servidor();
            server.Start();
        }
    }
}
