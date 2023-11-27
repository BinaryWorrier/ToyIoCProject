using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyIoCProject.App
{
    public interface IMyService
    {
        Task DoTheThingAsync();
    }

    internal class MyService : IMyService
    {
        private readonly IClock clock;

        public MyService(IClock clock)
        {
            this.clock = clock;
        }
        public Task DoTheThingAsync()
        {
            return Console.Out.WriteLineAsync($"Doing the thing now at {clock.Now}");
        }
    }
}
