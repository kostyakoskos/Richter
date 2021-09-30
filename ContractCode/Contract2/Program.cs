using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// контракты кода нужны чтобы не писать самому проверку входных данных
// проверку делает FCL
namespace Contract2
{
    public class Payment
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }
    }
    public class PaymentProcessor
    {
        private List<Payment> _payments = new List<Payment>();

        public void Add(Payment payment)
        {
            Contract.Requires(payment != null);
            Contract.Requires(!string.IsNullOrEmpty(payment.Name));
            Contract.Requires(payment.Date <= DateTime.Now);
            Contract.Requires(payment.Amount > 0);

            this._payments.Add(payment);
        }
        public void Add2(Payment[] payments)
        {
            Contract.Requires(
                (payments != null) &&
                Contract.ForAll(payments, payment => payment != null));

            foreach (var payment in payments)
            {
                this._payments.Add(payment);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var paymentProcessor = new PaymentProcessor();
            paymentProcessor.Add(null);

            var payments = new List<Payment>() {
                new Payment(),
                new Payment()
            };

            payments.Add(null);

            paymentProcessor.Add2(payments.ToArray());

            Console.ReadKey(true);
        }
    }
}
