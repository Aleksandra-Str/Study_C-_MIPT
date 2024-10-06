namespace DZ_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
          TaxiFactory horseTaxi = new HorseTaxiFactory();

          Client clientHorse = new Client(horseTaxi, "Иван", 30, "AB1452", 5);

          clientHorse.ProcessOrder();

            TaxiFactory trackTaxi = new TrackTaxiFactory();

            Client clientTrack = new Client(trackTaxi, "Петр", 40, "AC1412", 20);

            clientTrack.ProcessOrder();
        }
    }
}
