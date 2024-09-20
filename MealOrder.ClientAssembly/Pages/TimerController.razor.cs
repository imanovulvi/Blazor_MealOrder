using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace MealOrder.ClientAssembly.Pages
{
    public class TimerControllerBase:ComponentBase,IDisposable
    {
        [Inject]
        public ILocalStorageService localStorageService { get; set; }
        public int Count { get; set; }
        public Timer timer;
        public TimerControllerBase()
        {

            timer = new Timer(new TimerCallback(TimerCallback));
            
        }
        void TimerCallback(object obj)
        {
          
            InvokeAsync(() => {
                Count++;
                localStorageService.SetItemAsStringAsync("a" + Count, Count.ToString());

                StateHasChanged();

            });
        }
       protected void Start()
        {
            timer.Change(0, 3000);
        }
        protected void Stop()
        {
            timer.Change(0, 0);
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
