using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyIoCProject.App
{
    internal class MyApplication
    {
        private readonly IClock clock;
        private readonly IMyService myService;

        public MyApplication(IClock clock, IMyService myService)
        {
            this.clock = clock;
            this.myService = myService;
        }
        public async Task RunAsync()
        {
            await Console.Out.WriteLineAsync($"App started {clock.Now}");

            await Task.Delay(TimeSpan.FromSeconds(1));

            await myService.DoTheThingAsync();

            await Task.Delay(TimeSpan.FromSeconds(2));

            await Console.Out.WriteLineAsync($"App Stopping {clock.Now}");
        }
    }
}
