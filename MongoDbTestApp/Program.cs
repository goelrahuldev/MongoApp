using System;
using System.Linq;
using System.Reflection;
using MangoDbEnterprise.Domain.Entities.Todo;
using MangoDbEnterprise.Repositories;
using Ninject;

namespace MongoDbTestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IKernel kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());
            var todoRepository = kernal.Get<ITodoService>();

            using (todoRepository.RequestStart())
            {
                todoRepository.Add(new Todo { Title = "test" });

            }

            var filter = todoRepository.Select(cust => cust);
            filter.ToList().ForEach(x=>
            {
                Console.WriteLine("{0} - {1}", x.Id, x.Title);
            });
            Console.ReadKey();


        }
    }
}
