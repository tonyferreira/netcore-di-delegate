using System;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreDelegateInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            try {

               Action<string> log = (message) => Console.WriteLine(message);

                var serviceProvider = new ServiceCollection()
                                            .AddSingleton(log)
                                            .AddTransient(typeof(Person))
                                            .BuildServiceProvider();

            var person = (Person) serviceProvider.GetService(typeof(Person));
            person.LogSomething();

            }
            catch(Exception ex) {
                Console.Error.Write(ex);
            }
            finally {
                Console.ReadLine();
            }
        }
    }

    class Person {

        private Action<string> log;
        public Person(Action<string> log){
            this.log = log;
        }
        public void LogSomething() {
            log("Something");
        }
    }
}
