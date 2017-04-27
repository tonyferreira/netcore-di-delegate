using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreDelegateInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            try {

               Action<string> callback = (message) => Console.WriteLine(message);

                var serviceProvider = new ServiceCollection()
                                            .AddSingleton(callback)
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

        private Action<string> callback;
        public Person(Action<string> callback) {
            this.callback = callback;
        }
        public async void LogSomething() {
            await Task.Delay(3000);
            this.callback("Callback executed");
        }
    }
}
