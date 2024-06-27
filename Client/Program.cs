namespace Client
{
    internal class Program
    {
        private static Cliente cliente = null;

        static void Main(string[] args)
        {
            try
            {
                Iniciar();                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

        private async static void Iniciar()
        {
            cliente = new Cliente();
            await cliente.ConnectAsync("Usuário R");

            await Task.Delay(1000);

            Console.WriteLine("Cliente UP");

            Loop();
        }

        private async static void Loop()
        {
            while (true)
            {
                Console.WriteLine("DIGITE SUA MENSAGEM:");

                string mensagem = Console.ReadLine();

                if (mensagem != null && mensagem != string.Empty)
                {
                    await cliente.SendMessageAsync(mensagem);
                }
            }
        }
    }
}
