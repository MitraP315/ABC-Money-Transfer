namespace ABCExchange.Services
{
    public interface ITransactionServices
    {

    }
    public class TransanctionServices:ITransactionServices
    {

        private  string teRandomNumber()
        {
            var random = new Random();
            var digits = "0123456789";

            // Generate remaining 7 random digits
            var randomDigits = new char[10];
            for (int i = 0; i < 10;i++)
            {
                randomDigits[i] = digits[random.Next(digits.Length)];
            }
            return   new string(randomDigits);
        }
    }
}
