namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\MarcoF\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\my-addresses.csv";

            List<Address> addressesList = new();
            try
            {
                using (StreamReader read = new(filePath))
                {
                    string line;

                    while ((line = read.ReadLine()) != null)
                    {
                        string[] col = line.Split(",");

                        if (col.Length >= 6)
                        {
                            Address address = new Address
                            {
                                Name = col[0],
                                LastName = col[1],
                                Street = col[2],
                                City = col[3],
                                Province = col[4],
                                ZipCode = col[5]
                            };
                            addressesList.Add(address);
                        }
                        else
                        {
                            if (col.Length == 1 && string.IsNullOrEmpty(col[0]))
                            {
                                Console.WriteLine("Indirizzo mancante\n");
                            }
                            else
                            {
                                Console.WriteLine($"Dato mancante o inesatto: {line}\n ");
                            }
                        }
                    }
                }
                foreach( Address address in addressesList )
                {
                    Console.WriteLine( $"Nome: {address.Name}\nCognome: {address.LastName}\nIndirizzo: {address.Street}\nCittà: {address.City}\nProvincia: {address.Province}\nCAP: {address.ZipCode}\n" );
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Si è verificato un errore: {e.Message}");
            }
        }
    }
}